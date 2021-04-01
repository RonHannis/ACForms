import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-custom-collection-template-textbox',
  templateUrl: './custom-collection-template-textbox.component.html',
  styleUrls: ['./custom-collection-template-textbox.component.scss']
})
export class CustomCollectionTemplateTextboxComponent implements OnInit {

  @Input() reset: Observable<any>;

  @Input() value: any;
  @Input() key: string;
  @Input() mask = '';
  @Input() hint = '';
  @Output() changed = new EventEmitter();
  @Output() valid = new EventEmitter<boolean>();
  valControl: FormControl;

  constructor() { }

  ngOnInit(): void {
    this.valControl = new FormControl();

    this.valControl.valueChanges.subscribe(v => {
      var isNotEmpty = !!this.valControl.value;
      this.valid.emit(isNotEmpty && this.valControl.valid);
      this.changed.emit(v);
    })

    this.reset.subscribe(v => {
      this.valControl.reset();
    })

    this.valControl.setValue(this.value || this.initValue());
  }

  initValue(): void {
    this.value = '';
  }
}
