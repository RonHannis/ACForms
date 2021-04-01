import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-datebox',
  templateUrl: './question-datebox.component.html',
  styleUrls: ['./question-datebox.component.scss']
})
export class QuestionDateboxComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.Date>;
  @Input() ignoreReq: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }
}
