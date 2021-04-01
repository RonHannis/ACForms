import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ACQuestionnaireSection } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-questionnaire-progress',
  templateUrl: './questionnaire-progress.component.html',
  styleUrls: ['./questionnaire-progress.component.scss']
})
export class QuestionnaireProgressComponent implements OnInit {

  @Input() currentSectionId: number;
  @Input() sections: ACQuestionnaireSection[];

  @Output() selectSection = new EventEmitter<number>();

  onSelectSection(index: number): void {
    this.selectSection.emit(index);
  }


  constructor() { }

  ngOnInit(): void {
  }

}
