import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-custom-collection-template-medication',
  templateUrl: './custom-collection-template-medication.component.html',
  styleUrls: ['./custom-collection-template-medication.component.scss']
})
export class CustomCollectionTemplateMedicationComponent implements OnInit {


  @Input() value: any;
  @Input() key: string;
  @Output() changed = new EventEmitter<any>();

  get drug(): string {
    return this.getValueProp('drug');
  }

  set drug(drug: string) {
    this.value.drug = drug;
    this.onChanged();
  }

  get dose(): string {
    return this.getValueProp('dose');
  }

  set dose(dose: string) {
    this.value.dose = dose;
    this.onChanged();
  }

  get frequency(): string {
    return this.getValueProp('frequency');
  }

  set frequency(frequency: string) {
    this.value.frequency = frequency;
    this.onChanged();
  }

  get associatedDiagnosis(): string {
    return this.getValueProp('associatedDiagnosis');
  }

  set associatedDiagnosis(associatedDiagnosis: string) {
    this.value.associatedDiagnosis = associatedDiagnosis;
    this.onChanged();
  }

  get continueTreatment(): boolean {
    return this.getValueProp('continueTreatment');
  }

  set continueTreatment(continueTreatment: boolean) {
    this.value.continueTreatment = continueTreatment;
    this.onChanged();
  }

  getValueProp(property: string): any {
    if (this.value) {
      if (!this.value[property]) {
        this.value[property] = null;
      }
    } else {
      this.initValue();
    }
    return this.value[property];
  }

  initValue(): void {
    this.value = { drug: null, dose: null, frequency: null, associatedDiagnosis: null, continueTreatment: null };
  }

  onChanged(): void {
    this.changed.emit(this.value);
  }

  constructor() { }

  ngOnInit() {
    if (!this.value) { this.initValue(); }
  }
}
