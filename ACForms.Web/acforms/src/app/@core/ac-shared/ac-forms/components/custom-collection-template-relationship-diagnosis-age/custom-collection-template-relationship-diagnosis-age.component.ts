import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-custom-collection-template-relationship-diagnosis-age',
  templateUrl: './custom-collection-template-relationship-diagnosis-age.component.html',
  styleUrls: ['./custom-collection-template-relationship-diagnosis-age.component.scss']
})
export class CustomCollectionTemplateRelationshipDiagnosisAgeComponent implements OnInit {

  @Input() value: any;
  @Input() key: string;
  @Output() changed = new EventEmitter<any>();

  get relationship(): string {
    return this.getValueProp('relationship');
  }

  set relationship(relationship: string) {
    this.value.relationship = relationship;
    this.onChanged();
  }

  get diagnosis(): string {
    return this.getValueProp('diagnosis');
  }

  set diagnosis(diagnosis: string) {
    this.value.diagnosis = diagnosis;
    this.onChanged();
  }

  get age(): string {
    return this.getValueProp('age');
  }

  set age(age: string) {
    this.value.age = age;
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
    this.value = { relationship: null, diagnosis: null, age: null };
  }

  onChanged(): void {
    this.changed.emit(this.value);
  }

  constructor() { }

  ngOnInit(): void {
    if (!this.value) { this.initValue(); }
  }
}
