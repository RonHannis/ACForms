import { createAction, props } from '@ngrx/store';
import { ACQuestionnaire } from '../../@core/models/ac-forms.models';


export const loadForm = createAction(
  '[Forms] Load Form',
  props<{ access: string, id: string }>()
);
export const loadFormSuccess = createAction(
  '[Forms] Load Form Success',
  props<{ form: ACQuestionnaire }>()
);
export const loadFormFailed = createAction(
  '[Forms] Load Form Failed',
  props<{ error: any }>()
);


export const startNewForm = createAction(
  '[Forms] Start New Form',
  props<{ access: string, key: string, prefill: any }>()
);
export const startNewFormSuccess = createAction(
  '[Forms] Start New Form Success',
  props<{ access: string, id: string }>()
);
export const startNewFormFailed = createAction(
  '[Forms] Start New Form Failed',
  props<{ error: any }>()
);


export const saveForm = createAction(
  '[Forms] Save Form',
  props<{ access: string, id: string, form: any }>()
);
export const saveFormSuccess = createAction(
  '[Forms] Save Form Success'
);
export const saveFormFailed = createAction(
  '[Forms] Save Form Failed',
  props<{ error: any }>()
);

export const submitForm = createAction(
  '[Forms] Submit Form',
  props<{ access: string, id: string, form: any }>()
);
export const submitFormSuccess = createAction(
  '[Forms] Submit Form Success'
);
export const submitFormFailed = createAction(
  '[Forms] Submit Form Failed',
  props<{ error: any }>()
);

