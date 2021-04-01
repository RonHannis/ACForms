import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-custom-collection-template-surgery',
  templateUrl: './custom-collection-template-surgery.component.html',
  styleUrls: ['./custom-collection-template-surgery.component.scss']
})
export class CustomCollectionTemplateSurgeryComponent implements OnInit {

  @Input() value: any;
  @Input() key: string;
  @Output() changed = new EventEmitter<any>();

  get condition(): string {
    return this.getValueProp('condition');
  }

  set condition(condition: string) {
    this.value.condition = condition;
    this.onChanged();
  }

  get surgeryDate(): string {
    return this.getValueProp('surgeryDate');
  }

  set surgeryDate(surgeryDate: string) {
    this.value.surgeryDate = surgeryDate;
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
    this.value = { condition: null, surgeryDate: null };
  }

  onChanged(): void {
    this.changed.emit(this.value);
  }

  constructor() { }

  ngOnInit(): void {
    if (!this.value) { this.initValue(); }
  }

}
