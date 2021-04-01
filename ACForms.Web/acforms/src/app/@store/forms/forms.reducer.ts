import { Action, createReducer, on } from '@ngrx/store';
import * as FormsActions from './forms.actions';
import { ACQuestionnaire } from '../../@core/models/ac-forms.models';
import * as cloneDeep from 'lodash/clonedeep';

export const formsFeatureKey = 'forms';

export interface State {
  loadingStatus?: string;
  isSaving: boolean;
  error?: any;
  savingError?: any;
  form?: ACQuestionnaire
  status: string;
}

export const initialState: State = {
  loadingStatus: null,
  isSaving: false,
  error: null,
  savingError: null,
  form: null,
  status: null
};


export const reducer = createReducer(
  initialState,

  on(FormsActions.loadForm, (state) => ({
    ...state,
    loadingStatus: 'Loading',
    error: null,
    form: null,
    status: null
  })),
  on(FormsActions.loadFormSuccess, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: null,
    form: cloneDeep(action.form),
    status: action.form.status
  })),
  on(FormsActions.loadFormFailed, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: action.error,
  })),

  on(FormsActions.startNewForm, (state) => ({
    ...state,
    loadingStatus: 'Initializing',
    error: null,
    form: null,
    status: null
  })),
  on(FormsActions.startNewFormSuccess, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: null,
  })),
  on(FormsActions.startNewFormFailed, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: action.error,
  })),

  on(FormsActions.submitForm, (state) => ({
    ...state,
    loadingStatus: 'Submitting',
    error: null
  })),
  on(FormsActions.submitFormSuccess, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: null,
    status: "Submitted"
  })),
  on(FormsActions.submitFormFailed, (state, action) => ({
    ...state,
    loadingStatus: null,
    error: action.error
  })),

  on(FormsActions.saveForm, (state, action) => ({
    ...state,
    isSaving: true,
    savingError: null,
  })),
  on(FormsActions.saveFormSuccess, (state, action) => ({
    ...state,
    isSaving: false,
    savingError: null,
  })),
  on(FormsActions.saveFormFailed, (state, action) => ({
    ...state,
    isSaving: false,
    savingError: action.error
  }))
);

