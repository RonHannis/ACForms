import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ACQuestionnaireSection } from '../../../../models/ac-forms.models';

@Component({
  selector: 'app-questionnaire-navigation',
  templateUrl: './questionnaire-navigation.component.html',
  styleUrls: ['./questionnaire-navigation.component.scss']
})
export class QuestionnaireNavigationComponent implements OnInit {

  @Input() currentSectionId: number;
  @Input() sections: ACQuestionnaireSection[];

  @Output() selectSection = new EventEmitter<number>();
  @Output() submitQuestionnaire = new EventEmitter<Date>();

  get currentSectionTitle(): string {
    return this.sections[this.currentSectionId].label;
  }

  get nextDisabled(): boolean {
    return this.currentSectionId >= this.sections.length - 1;
  }

  get prevDisabled(): boolean {
    return this.currentSectionId === 0;
  }

  next(): void {
    this.onSelectSection(this.currentSectionId + 1);
  }

  prev(): void {
    this.onSelectSection(this.currentSectionId - 1);
  }

  submit(): void {
    this.submitQuestionnaire.emit(new Date());
  }


  private onSelectSection(index: number): void {
    this.selectSection.emit(index);
  }

  constructor() { }

  ngOnInit(): void {
  }

}
