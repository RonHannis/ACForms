import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireSection, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-custom-questionnaire-section',     
  templateUrl: './custom-questionnaire-section.component.html',
  styleUrls: ['./custom-questionnaire-section.component.scss']
})
export class CustomQuestionnaireSectionComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() section: ACQuestionnaireSection;
  @Output() onSelect = new EventEmitter();

  selectedOption = {
    key: null,
    value: null
  };
  loopCount = {
    key: null,
    value: null
  };

  questionTypes = ACQuestionnaireQuestionTypes;

  constructor() { }

  ngOnInit(): void {
    for (const question of this.section.questions) {
      if (question.type === this.questionTypes.SelectOne) {
        if (question.options && question.options.length) {
          this.selectedOption = {
            key: question.key,
            value: question.options[0]
          };
        }
      }
    }
  }

  onOptionChanged($event): void {
    if ($event && $event['condition']['step'].length > 0) {
      this.onSelect.emit($event);
    } else {
      this.selectedOption = $event;
    }
  }

  onTextChange($event): void {
    this.loopCount = $event;
  }

  isVisible(question): any {
    if (question.loopTemplate) {
      return false;
    } else if (!question.visible) {
      return true;
    } else {
      if (question.visible === 'hidden') {
        if (this.selectedOption && this.selectedOption['condition']) {
          if (this.selectedOption['condition']['key'] && this.selectedOption['condition']['key'].length > 0) {
            if (this.selectedOption['condition']['key'].indexOf(question.key) >= 0) {
              if (this.selectedOption['condition']['value'] && this.selectedOption['condition']['value'].length > 0) {
                if (this.selectedOption['condition']['value'].indexOf(this.selectedOption['value']) >= 0) {
                  return true;
                }
              }
            }
          }
        }
        return false;
      } else if (question.visible === 'show') {
        if (this.selectedOption && this.selectedOption['condition']) {
          if (this.selectedOption['condition']['key'] && this.selectedOption['condition']['key'].length > 0) {
            if (this.selectedOption['condition']['key'].indexOf(question.key) >= 0) {
              if (this.selectedOption['condition']['value'] && this.selectedOption['condition']['value'].length > 0) {
                if (this.selectedOption['condition']['value'].indexOf(this.selectedOption['value']) >= 0) {
                  return true;
                }
              }
              return false;
            }
            return true;
          }
          return true;
        }
      }
      return true;
    }
  }
}
