import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcFormsModule } from './ac-forms/ac-forms.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AcFormsModule,
  ],
  exports: [
    AcFormsModule
  ]
})
export class AcSharedModule { }
