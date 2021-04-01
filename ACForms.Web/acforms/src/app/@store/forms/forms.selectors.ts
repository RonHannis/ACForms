import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromForms from './forms.reducer';


export const selectFormsState = createFeatureSelector<fromForms.State>(
  fromForms.formsFeatureKey
);

export const selectForm = createSelector(
  selectFormsState,
  state => state.form
);

export const selectFormStatus = createSelector(
  selectFormsState,
  state => state.status
);

export const selectFormLoadingStatus = createSelector(
  selectFormsState,
  state => state.loadingStatus
);
