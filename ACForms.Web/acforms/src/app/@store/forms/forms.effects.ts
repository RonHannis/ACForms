import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { FormsService } from '../../@core/services/forms.service';
import * as FormsActions from './forms.actions';




@Injectable()
export class FormsEffects {

  loadForm$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.loadForm),
      switchMap(action =>
        this.formsSerivce.getForm(action.access, action.id).pipe(
          map(r => FormsActions.loadFormSuccess({ form: r })),
          catchError(e => of(FormsActions.loadFormFailed({ error: e }))
          )
        )
      )
    )
  );

  startNewForm$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.startNewForm),
      switchMap(action =>
        this.formsSerivce.startNewForm(action.access, action.key, action.prefill).pipe(
          map(r => FormsActions.startNewFormSuccess({ access: action.access, id: r.id })),
          catchError(e => of(FormsActions.startNewFormFailed({ error: e }))
          )
        )
      )
    )
  );

  startNewFormSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.startNewFormSuccess),
      tap(action => this.router.navigate([`/${action.access}/${action.id}`]))
    ),
    { dispatch: false }
  );


  saveForm$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.saveForm),
      switchMap(action =>
        this.formsSerivce.saveForm(action.access, action.id, action.form).pipe(
          map(r => FormsActions.saveFormSuccess()),
          catchError(e => of(FormsActions.startNewFormFailed({ error: e }))
          )
        )
      )
    )
  );

  saveFormSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.startNewFormSuccess),
      tap(action => this.router.navigate([`/${action.access}/${action.id}`]))
    ),
    { dispatch: false }
  );

  submitForm$ = createEffect(() =>
    this.actions$.pipe(
      ofType(FormsActions.submitForm),
      switchMap(action =>
        this.formsSerivce.submitForm(action.access, action.id, action.form).pipe(
          map(r => FormsActions.submitFormSuccess()),
          catchError(e => of(FormsActions.startNewFormFailed({ error: e }))
          )
        )
      )
    )
  );


  constructor(
    private actions$: Actions,
    private formsSerivce: FormsService,
    private router: Router
  ) { }

}
