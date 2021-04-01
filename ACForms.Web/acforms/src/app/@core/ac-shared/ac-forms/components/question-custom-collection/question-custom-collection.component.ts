import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes, ACCustomCollectionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-custom-collection',
  templateUrl: './question-custom-collection.component.html',
  styleUrls: ['./question-custom-collection.component.scss']
})
export class QuestionCustomCollectionComponent implements OnInit {

  private resetSubject: BehaviorSubject<any> = new BehaviorSubject(null);

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.CustomCollection>;

  collectionTypes = ACCustomCollectionTypes;
  tempValue: any = null;
  tempValid: boolean = true;
  reset: Observable<any> = this.resetSubject.asObservable();

  onTempChanged(value: any): void {
    this.tempValue = value;
  }

  onTempValidChanged(value: boolean): void {
    this.tempValid = value;
  }

  get value(): any[] {
    return this.group.get(this.question.formKey).value as any[];
  }

  get q() { return this.group.get(this.question.formKey) }

  add(): void {
    let v = (this.group.get(this.question.formKey).value as any[]);
    v.push(this.tempValue)
    this.group.get(this.question.formKey).setValue(v);
    this.tempValue = null;
    this.resetSubject.next(null);
  }

  delete(index: number): void {
    let v = (this.group.get(this.question.formKey).value as any[]);
    v.splice(index, 1);
    this.group.get(this.question.formKey).setValue(v);
  }

  constructor() { }

  ngOnInit(): void {
    if (!this.group.get(this.question.formKey).value) { this.group.get(this.question.formKey).setValue([]); }
  }

  parseValue(value): any {
    const stringConstructor = 'string'.constructor;
    const arrayConstructor = [].constructor;
    const objectConstructor = ({}).constructor;
    let result = '';
    if (value) {
      if (value.constructor === objectConstructor) {
        for (const key in value) {
          result += `<div style="margin-bottom: 1rem">
            <span>${key.charAt(0).toUpperCase() + key.slice(1)}: </span>
            <span> ${this.isDateValue(value[key]) ? this.formatDate(value[key]) : value[key]}</span>
          </div>`;
        }
      } else {
        result = value;
      }
      return result;
    }
  }

  isDateValue(value): any {
    const isValidDate = Date.parse(value);
    if (isValidDate < 0 || isNaN(isValidDate)) {
      return false;
    }
    return true;
  }

  formatDate(date): any {
    const dateValue = new Date(date);
    const year = dateValue.getFullYear();
    let month = (dateValue.getMonth() + 1).toString();
    month = month.length === 1 ? '0' + month : month;
    let day = (dateValue.getDate()).toString();
    day = day.length === 1 ? '0' + day : day;
    return `${month}/${day}/${year}`;

  }
}
