import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcSharedModule } from '../@core/ac-shared/ac-shared.module';
import { FormsRoutingModule } from './forms-routing.module';
import { FormsComponent } from './forms.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { FormsEffects, FormsStore } from '../@store/forms';
import { NewFormComponent } from './new-form/new-form.component';


@NgModule({
  declarations: [FormsComponent, NewFormComponent],
  imports: [
    CommonModule,
    FormsRoutingModule,
    AcSharedModule,
    StoreModule.forFeature(FormsStore.formsFeatureKey, FormsStore.reducer),
    EffectsModule.forFeature([FormsEffects]),
  ]
})
export class FormsModule { }
