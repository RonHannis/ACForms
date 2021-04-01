import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-custom-collection-template-diagnosis',
  templateUrl: './custom-collection-template-diagnosis.component.html',
  styleUrls: ['./custom-collection-template-diagnosis.component.scss']
})
export class CustomCollectionTemplateDiagnosisComponent implements OnInit {

  @Input() value: any;
  @Input() key: string;
  @Output() changed = new EventEmitter<any>();

  options = ['Active', 'Inactive', 'Chronic'];

  get diagnosis(): string {
    return this.getValueProp('diagnosis');
  }

  set diagnosis(diagnosis: string) {
    this.value.diagnosis = diagnosis;
    this.onChanged();
  }

  get status(): string {
    return this.getValueProp('status');
  }

  set status(status: string) {
    this.value.status = status;
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
    this.value = { diagnosis: null, status: null };
  }

  onChanged(): void {
    this.changed.emit(this.value);
  }

  constructor() { }

  ngOnInit(): void {
    if (!this.value) { this.initValue(); }
  }

}
