import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes, ACTextboxWithEventTypes } from '../../../../models/ac-forms.models';
import { FormfieldsService } from '../../../../services/formfields.service';

@Component({
  selector: 'app-question-text-with-event',
  templateUrl: './question-text-with-event.component.html',
  styleUrls: ['./question-text-with-event.component.scss']
})
export class QuestionTextWithEventComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.TextboxWithEvent>;
  @Input() ignoreReq: boolean = false;

  textboxEventTypes = ACTextboxWithEventTypes;

  constructor(
    private fieldService: FormfieldsService,
  ) { }

  ngOnInit(): void {
  }

  onTextboxWithEventChanged(e): void {
    if (this.question.textboxEventType == "Username")
      this.fieldService.checkUsernameIsAvailable(e.currentTarget.value);
  }

}
