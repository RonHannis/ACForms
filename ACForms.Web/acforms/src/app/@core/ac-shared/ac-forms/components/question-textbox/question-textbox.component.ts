import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-textbox',
  templateUrl: './question-textbox.component.html',
  styleUrls: ['./question-textbox.component.scss']
})
export class QuestionTextboxComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.Text | ACQuestionnaireQuestionTypes.Date>;
  @Input() ignoreReq: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }
}
