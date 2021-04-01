import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-question-textarea',
  templateUrl: './question-textarea.component.html',
  styleUrls: ['./question-textarea.component.scss']
})
export class QuestionTextareaComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.TextArea>;

  constructor() { }

  ngOnInit(): void {
  }
}
