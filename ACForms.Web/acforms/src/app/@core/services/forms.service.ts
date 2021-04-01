import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ACQuestionnaire, ACQuestionnaireSection } from '../models/ac-forms.models';
import { FormfieldsService } from '../services/formfields.service';

@Injectable({
  providedIn: 'root'
})
export class FormsService {

  startNewForm(accessLevel: string, key: string, params: any): Observable<{ id: string, key: string, accessLevel: string }> {
    return this.http.post<{ id: string, key: string, accessLevel: string }>(`/api/${accessLevel}forms/${key}/start`, params);
  }

  getForm(accessLevel: string, id: string): Observable<ACQuestionnaire> {
    return this.http.get<ACQuestionnaire>(`/api/${accessLevel}forms/${id}`);
  }

  saveForm(accessLevel: string, id: string, form: any): Observable<any> {
    var values = this.getValues(form);
    return this.http.put(`/api/${accessLevel}forms/${id}`, { data: values });
  }

  submitForm(accessLevel: string, id: string, form: any): Observable<any> {
    var values = this.getValues(form);
    return this.http.post(`/api/${accessLevel}forms/${id}`, { data: values });
  }

  uploadFiles(accessLevel: string, id: string, formData: FormData): Observable<any> {
    return this.http.post(`/api/${accessLevel}forms/${id}/files`, formData, { reportProgress: true, observe: 'events' });
  }

  constructor(
    private http: HttpClient,
    private fieldService: FormfieldsService,
  ) { }


  getFormGroups(q: ACQuestionnaire): FormGroup {
    if (q === null) return null;
    const fg = {};
    q.sections.forEach(s => {
      fg[s.key] = this.getSectionFormGroup(s);
    });

    fg['finalize'] = this.getFinalizeFormGroup(q);
    return new FormGroup(fg);
  }

  getFinalizeFormGroup(q: ACQuestionnaire): FormGroup {
    const fg = {};
    if (q.allowAttachments) {
      fg['attachments'] = q.requireAttachments ? new FormControl(q.attachments, Validators.required) : new FormControl(q.attachments);
    }
    return new FormGroup(fg);
  }


  requiredIfValidator(predicate): ValidatorFn {
    return (formControl => {
      if (!formControl.parent) {
        return null;
      }
      if (predicate()) {
        return Validators.required(formControl);
      }
      return null;
    })
  }

  requiredItems(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const arr = control.value as any[];
      return arr && arr.length > 0 ? null : { requiredItems: true };
    };
  }

  private getSectionFormGroup(s: ACQuestionnaireSection): FormGroup {
    const fg = {};

    if (s.questions) {
      s.questions.forEach(q => {
        if (q.customValidator) {
          if (q.customValidator == "Username") {
            fg[q.formKey] = new FormControl(q.value, [Validators.required], [this.fieldService.usernameValidator()]);
          }
        } else {
          fg[q.formKey] = q.required ? new FormControl(q.value, Validators.required) : new FormControl(q.value);
        }
        if (q.questions) {
          q.questions.forEach(qsub => {
            fg[qsub.formKey] = qsub.required ? new FormControl(qsub.value, this.requiredIfValidator(() => fg[q.formKey].value)) : new FormControl(qsub.value);
          });
        }
      });
    }

    if (s.sections) {
      s.sections.forEach(sub => {
        if (sub.questions) {
          sub.questions.forEach(q => {
            fg[q.formKey] = q.required ? new FormControl({ value: q.value, disabled: q.readOnly }, Validators.required) : new FormControl({ value: q.value, disabled: q.readOnly });
          })
        }
      });
    }

    return new FormGroup(fg);
  }

  private getValues(formdata: any): any {
    let values = {};
    for (const [k, v] of Object.entries(formdata)) {
      values = { ...values, ...formdata[k] };
    }

    return values;
  }

}
