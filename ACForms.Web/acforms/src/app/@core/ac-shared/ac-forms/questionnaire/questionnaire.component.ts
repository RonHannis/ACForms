import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ACQuestionnaire } from '../../../models/ac-forms.models';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { FormGroup } from '@angular/forms';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.scss'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: { showError: true }
  }]
})
export class QuestionnaireComponent implements OnInit {

  @Input() form: FormGroup;
  @Input() questionnaire: ACQuestionnaire;
  @Input() data: any;
  @Input() status: string;
  @Output() changed = new EventEmitter<{ data: any }>();
  @Output() submitted = new EventEmitter<{ data: any }>();

  showSteps = [];

  onSubmitted(): void {
    this.submitted.emit({ data: this.form.getRawValue() });
  }

  constructor() { }

  ngOnInit(): void {
    this.form.valueChanges.pipe(debounceTime(2000)).subscribe(f => {
      this.changed.emit({
        data: f
      });
    });
  }

  skipStep(stepper): void {
    if (stepper && stepper.condition && stepper.condition.step && stepper.condition.step.length > 0) {
      if (stepper.condition.value.indexOf(stepper.value) >= 0) {
        this.showSteps = stepper.condition.step;
        return;
      }
    }
    this.showSteps = [];
  }

  isShowStep(key): boolean {
    if (this.showSteps.indexOf(key) >= 0) {
      return true;
    }
    return false;
  }

}
