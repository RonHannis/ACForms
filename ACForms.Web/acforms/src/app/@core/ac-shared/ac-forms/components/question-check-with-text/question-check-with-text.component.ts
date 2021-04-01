import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-check-with-text',
  templateUrl: './question-check-with-text.component.html',
  styleUrls: ['./question-check-with-text.component.scss']
})
export class QuestionCheckWithTextComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.CheckWithText>;

  questionTypes = ACQuestionnaireQuestionTypes;

  get ignoreReq() {
    return !this.group.get(this.question.formKey).value;
  }
  constructor() { }

  ngOnInit(): void {
  }

}
