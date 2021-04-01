import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ACQuestionnaireQuestion, ACQuestionnaireQuestionTypes } from '../../../../models/ac-forms.models';
import { FormfieldsService } from '../../../../services/formfields.service';

@Component({
  selector: 'app-question-text-with-event-username',
  templateUrl: './question-text-with-event-username.component.html',
  styleUrls: ['./question-text-with-event-username.component.scss']
})
export class QuestionTextWithEventUsernameComponent implements OnInit {

  @Input() group: FormGroup;
  @Input() question: ACQuestionnaireQuestion<ACQuestionnaireQuestionTypes.TextboxWithEvent>;

  message: string = "";
  usernameAvailable: boolean = false;

  constructor(
    private fieldService: FormfieldsService
  ) { }

  ngOnInit(): void {

    this.fieldService.IsUsernameAvailable.subscribe(available => {
      if (available == null) {
        this.usernameAvailable = false;
        this.message = "";
      } else if (available) {
        this.usernameAvailable = true;
        this.message = "";
      } else {
        this.usernameAvailable = false;
        this.message = "This username is already taken!"
      }
    });
  }
}
