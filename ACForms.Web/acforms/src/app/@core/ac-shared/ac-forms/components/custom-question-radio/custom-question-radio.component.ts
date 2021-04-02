import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-custom-question-radio',
  templateUrl: './custom-question-radio.component.html',
  styleUrls: ['./custom-question-radio.component.scss']
})
export class CustomQuestionRadioComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.SelectOne>;
  @Output() onSelect = new EventEmitter();
  @Input() index: any = 0;
  questionTypes = ACQuestionnaireQuestionTypes;
  get q() { return this.group.get(this.question.formKey) }

  constructor() { }

  ngOnInit(): void {

  }

  onOptionClick($event): void {
    if ($event) {
      if (this.question['condition']['key'] && this.question['condition']['key'].length > 0) {
        const optionObj = {
          condition: this.question['condition'],
          value: $event.value
        };
        this.onSelect.emit(optionObj);
      } 
    }
  }

}

