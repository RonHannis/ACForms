import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProviderGuard, MemberGuard } from './@auth/guards';

const routes: Routes = [
  {
    path: 'member',
    loadChildren: () => import('./forms/forms.module').then((m) => m.FormsModule),
    data: { type: 'member' },
    canActivate: [MemberGuard],
  },
  {
    path: 'provider',
    loadChildren: () => import('./forms/forms.module').then((m) => m.FormsModule),
    data: { type: 'provider' },
    canActivate: [ProviderGuard],
  },
  {
    path: 'public',
    loadChildren: () => import('./forms/forms.module').then((m) => m.FormsModule),
    data: { type: 'public' },
    // canActivate: []
  },
  {
    path: '**',
    redirectTo: 'public'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
