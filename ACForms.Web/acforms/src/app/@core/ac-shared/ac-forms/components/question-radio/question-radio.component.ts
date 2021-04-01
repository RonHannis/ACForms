import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-radio',
  templateUrl: './question-radio.component.html',
  styleUrls: ['./question-radio.component.scss']
})
export class QuestionRadioComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.SelectOne>;

  questionTypes = ACQuestionnaireQuestionTypes;

  get q() { return this.group.get(this.question.formKey) }

  constructor() { }

  ngOnInit(): void {
  }

}
