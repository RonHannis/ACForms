import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-custom-question-textbox',
  templateUrl: './custom-question-textbox.component.html',
  styleUrls: ['./custom-question-textbox.component.scss']
})
export class CustomQuestionTextboxComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.Text | ACQuestionnaireQuestionTypes.Date>;
  @Input() ignoreReq: boolean = false;
  @Output() onChange = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  
  onTextChange($event): void {
    if ($event) {
      if (this.question['loop'] && this.question['loop'].key.length > 0) {
        const data = {
          key: this.question['loop'].key,
          value: $event
        };
        this.onChange.emit(data);
      }
    }
   
  }
   
}
