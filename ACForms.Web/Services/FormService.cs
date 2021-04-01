using ACForms.Web.DAL;
using ACForms.Web.DAL.Models;
using ACForms.Web.Processors;
using ACForms.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACForms.UiPath.DAL;
using ACForms.UiPath.DAL.Models;

namespace ACForms.Web.Services
{
    public class FormService : IFormService
    {
        private readonly ACFormsDbContext _db;
        private readonly UiPathFormsContext _uiPathDb;
        private readonly FormProcessor _formProcessor;
        private readonly PreFillProcessor _preFillProcessor;
        private readonly IFormAttachmentService _attachmentService;

        public FormService(ACFormsDbContext dbContext, UiPathFormsContext uiPathFormsContext, FormProcessor formProcessor, PreFillProcessor preFillProcessor, IFormAttachmentService attachmentService)
        {
            _db = dbContext;
            _uiPathDb = uiPathFormsContext;
            _formProcessor = formProcessor;
            _preFillProcessor = preFillProcessor;
            _attachmentService = attachmentService;

        }

        public async Task<FormEntry> GetFormEntryAsync(FormAccessLevel accessLevel, Guid id)
        {
            var entry = await _db.Entries
                .Include(o => o.Form)
                .Include(o => o.Attachments)
                .FirstOrDefaultAsync(e => e.Id == id && e.Form.AccessLevel == accessLevel);
            if (entry is null) throw new Exception("No matching entry");
            return entry;
        }

        //public async Task<FormOCIF> GetOCIFAsync(Guid id)
        //{
        //    var ocif = await _db.FormOCIF.FirstOrDefaultAsync(e => e.Id == id);
        //    return ocif;
        //}

        public async Task<OCIF> GetOCIFAsync(Guid id)
        {
            var ocif = await _uiPathDb.OCIF.FirstOrDefaultAsync(e => e.ID == id);
            return ocif;
        }

        public async Task<Guid> StartNewFormAsync(FormAccessLevel accessLevel, string key, PreFillLookupCriteria criteria)
        {
            var form = await _db.Forms.FirstOrDefaultAsync(f => f.AccessLevel == accessLevel && f.Key == key);

            if (form is null) throw new Exception("No matching form");

            var entry = new FormEntry
            {
                FormKey = form.Key,
                PrefillCriteria = criteria,
                Status = FormStatus.Open,
            };

            var preFillProcessors = await _db.PreFillProcessors.Where(p => p.FormKey == key).ToArrayAsync();
            foreach (var processor in preFillProcessors)
            {
                await _preFillProcessor.ProcessFormAsync(processor, entry);
            }

            if (form.Key == "ocif")
            {
                //var ocif = new FormOCIF
                //{
                //    Id = entry.Id,
                //    Data = entry.Data,
                //};

                //await _db.AddAsync(ocif);

                var ocif = new OCIF
                {
                    ID = entry.Id,
                    JSONData = entry.Data
                };

                await _uiPathDb.AddAsync(ocif);
                await _uiPathDb.SaveChangesAsync();

            }

            await _db.AddAsync(entry);
            await _db.SaveChangesAsync();

            return entry.Id;
        }

        public async Task SubmitFormDataAsync(FormAccessLevel accessLevel, Guid id, string data)
        {
            var entry = await GetFormEntryAsync(accessLevel, id);
            if (entry.Status == FormStatus.Open)
            {
                entry.Data = data;
                entry.Status = FormStatus.Submitted;
                entry.SubmissionDate = DateTime.UtcNow;

                _db.Update(entry);

                if (entry.FormKey == "ocif")
                {
                    //var ocif = await GetOCIFAsync(id);
                    //if (ocif != null)
                    //{
                    //    ocif.Data = data;
                    //    _db.Update(ocif);

                    //}
                    //else
                    //{
                    //    ocif = new FormOCIF();
                    //    ocif.Id = id;
                    //    ocif.Data = data;
                    //    _db.Add(ocif);
                    //}

                    var ocif = await GetOCIFAsync(id);
                    if (ocif != null)
                    {
                        ocif.JSONData = data;
                        _uiPathDb.Update(ocif);
                    }
                    else
                    {
                        ocif = new OCIF();
                        ocif.ID = id;
                        ocif.JSONData = data;
                        await _uiPathDb.AddAsync(ocif);
                    }

                    await _uiPathDb.SaveChangesAsync();
                }

                await _db.SaveChangesAsync();

                await ProcessForm(entry);
            }

        }

        public async Task UpdateFormDataAsync(FormAccessLevel accessLevel, Guid id, string data)
        {
            var entry = await GetFormEntryAsync(accessLevel, id);

            entry.Data = data;

            _db.Update(entry);

            if (entry.FormKey == "ocif")
            {
                //var ocif = await GetOCIFAsync(id);
                //if (ocif != null)
                //{
                //    ocif.Data = data;
                //    _db.Update(ocif);

                //}
                //else
                //{
                //    ocif = new FormOCIF();
                //    ocif.Id = id;
                //    ocif.Data = data;
                //    await _db.AddAsync(ocif);
                //}

                var ocif = await GetOCIFAsync(id);
                if (ocif != null)
                {
                    ocif.JSONData = data;
                    _uiPathDb.Update(ocif);
                }
                else
                {
                    ocif = new OCIF();
                    ocif.ID = id;
                    ocif.JSONData = data;
                    await _uiPathDb.AddAsync(ocif);
                }
                await _uiPathDb.SaveChangesAsync();
            }

            await _db.SaveChangesAsync();
        }

        public async Task<FormEntryAttachment> UploadFileAttachmentAsync(FormAccessLevel accessLevel, Guid id, string filename, Stream file)
        {
            var entry = await GetFormEntryAsync(accessLevel, id);

            if (entry.Status != FormStatus.Open) throw new Exception("cannot upload file");

            await _attachmentService.SaveAttachmentAsync(id, filename, file);

            var attachment = await _db.Attachments.FirstOrDefaultAsync(a => a.EntryId == entry.Id && filename.Equals(a.Filename));
            if (attachment is null)
            {
                attachment = new FormEntryAttachment
                {
                    EntryId = id,
                    Filename = filename,
                    Path = $"{id}/{filename}"
                };

                await _db.AddAsync(attachment);

                await _db.SaveChangesAsync();
            }

            return attachment;
        }

        public async Task DeleteFileAttachmentAsync(FormAccessLevel accessLevel, Guid id, long attachmentId)
        {
            var entry = await GetFormEntryAsync(accessLevel, id);

            if (entry.Status != FormStatus.Open) throw new Exception("cannot delete file");

            var attachment = await _db.Attachments.FirstOrDefaultAsync(a => a.EntryId == id && a.Id == attachmentId);
            await _attachmentService.DeleteAttachmentAsync(id, attachment.Filename);
        }


        private async Task ProcessForm(FormEntry formEntry)
        {
            var processors = await _db.FormProcessors.Where(o => o.FormKey == formEntry.FormKey).ToArrayAsync();
            var tasks = new List<Task>();

            // process the archive first if it exists
            var archiveProcessor = processors.FirstOrDefault(p => p.ProcessorType == FormProcessorType.Archive);
            if (archiveProcessor != null)
            {
                await _formProcessor.ProcessFormAsync(archiveProcessor, formEntry);
            }


            foreach (var processor in processors.Where(p => p.ProcessorType != FormProcessorType.Archive))
            {
                tasks.Add(_formProcessor.ProcessFormAsync(processor, formEntry));
            }

            await Task.WhenAll(tasks);
        }
    }
}
