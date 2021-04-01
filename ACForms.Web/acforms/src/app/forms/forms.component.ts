import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data } from '@angular/router';
import { FormsSelectors, FormsStore, FormsActions } from '../@store/forms'
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import * as cloneDeep from 'lodash/clonedeep';
import { FormGroup } from '@angular/forms';
import { FormsService } from '../@core/services/forms.service';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.scss']
})
export class FormsComponent implements OnInit {

  form$ = this.store.select(FormsSelectors.selectForm);
  status$ = this.store.select(FormsSelectors.selectFormStatus);
  loadingStatus$ = this.store.select(FormsSelectors.selectFormLoadingStatus)
  id: string;
  access: string;
  formgroup: FormGroup;

  onChange(obj: { data: any }) {
    this.store.dispatch(FormsActions.saveForm({ access: this.access, id: this.id, form: obj.data }));
  }

  onSubmit(obj: { data: any }) {
    this.store.dispatch(FormsActions.submitForm({ access: this.access, id: this.id, form: obj.data }));
  }

  constructor(
    private store: Store<FormsStore.State>,
    private activatedRoute: ActivatedRoute,
    private formsService: FormsService
  ) {
  }

  ngOnInit(): void {
    const urlParams = combineLatest(
      this.activatedRoute.data,
      this.activatedRoute.params,
      this.activatedRoute.queryParams,
      (data, params, queryParams) => ({ data: { ...data }, params: { ...params }, query: { ...queryParams } })
    );

    urlParams.subscribe(routeParams => {
      this.id = routeParams.params.id;
      this.access = routeParams.data.type;
      this.store.dispatch(FormsActions.loadForm({ access: routeParams.data.type, id: routeParams.params.id }));
    });

    this.form$.subscribe(f => {
      if (f === null) return;
      this.formgroup = this.formsService.getFormGroups(f);
    });



  }

}
