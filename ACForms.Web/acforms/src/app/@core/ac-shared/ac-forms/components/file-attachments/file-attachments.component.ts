import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { combineLatest, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ACQuestionnaireAttachment } from '../../../../models/ac-forms.models';
import { FormsService } from '../../../../services/forms.service';

@Component({
  selector: 'app-file-attachments',
  templateUrl: './file-attachments.component.html',
  styleUrls: ['./file-attachments.component.scss']
})
export class FileAttachmentsComponent implements OnInit {

  @ViewChild("fileUpload", { static: false })
  fileUpload: ElementRef;
  files = [];
  

  @Input() group: FormGroup;
  @Input() attachments: ACQuestionnaireAttachment[];

  id: string;
  access: string;

  constructor(
    private formsService: FormsService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const urlParams = combineLatest(
      this.activatedRoute.data,
      this.activatedRoute.params,
      this.activatedRoute.queryParams,
      (data, params, queryParams) => ({ data: { ...data }, params: { ...params }, query: { ...queryParams } })
    );

    urlParams.subscribe(routeParams => {
      this.id = routeParams.params.id;
      this.access = routeParams.data.type;
    });
  }

  onClick() {
    const fileUpload = this.fileUpload.nativeElement; fileUpload.onchange = () => {
      for (let index = 0; index < fileUpload.files.length; index++) {
        const file = fileUpload.files[index];
        this.files.push({ name: file.name, data: file, inProgress: false, progress: 0 });
      }
      this.uploadFiles();
    };
    fileUpload.click();
  }

  get completedFiles(): any[] {
    return this.group.get('attachments').value as any[];
  }
  get q(): any {
    return this.group.get('attachments');
  }

  uploadFile(file) {
    const formData = new FormData();
    formData.append('file', file.data);
    file.inProgress = true;
    this.formsService.uploadFiles(this.access, this.id, formData).pipe(
      map(event => {
        switch (event.type) {
          case HttpEventType.UploadProgress:
            file.progress = Math.round(event.loaded * 100 / event.total);
            break;
          case HttpEventType.Response:
            return event;
        }
      }),
      catchError((error: HttpErrorResponse) => {
        file.inProgress = false;
        return of(`${file.data.name} upload failed.`);
      })).subscribe((event: any) => {
        if (typeof (event) === 'object') {
          if (this.completedFiles.findIndex(o => o.id === event.body.id) < 0) {
            let f = this.completedFiles
            f.push(event.body);
            this.group.get('attachments').setValue(f);
          }
          this.files = this.files.filter(o => o.name !== file.name);
          console.log(event.body);
        }
      });
  }


  private uploadFiles() {
    this.fileUpload.nativeElement.value = '';
    this.files.filter(o => !o.inProgress).forEach(file => {
      this.uploadFile(file);
    });
  }

}
