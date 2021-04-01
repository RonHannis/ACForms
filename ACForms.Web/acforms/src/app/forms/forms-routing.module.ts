import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsComponent } from './forms.component';
import { NewFormComponent } from './new-form/new-form.component';

const routes: Routes = [
  { path: ':id', component: FormsComponent },
  { path: ':key/new', component: NewFormComponent },
  { path: '', component: FormsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FormsRoutingModule { }
