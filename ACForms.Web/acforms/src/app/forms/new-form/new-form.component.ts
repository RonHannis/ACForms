import { Component, OnInit } from '@angular/core';
import { FormsActions, FormsStore } from '../../@store/forms';
import { Store } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { Observable, combineLatest } from 'rxjs';

@Component({
  selector: 'app-new-form',
  templateUrl: './new-form.component.html',
  styleUrls: ['./new-form.component.scss']
})
export class NewFormComponent implements OnInit {

  constructor(
    private store: Store<FormsStore.State>,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const urlParams = combineLatest(
      this.activatedRoute.data,
      this.activatedRoute.params,
      this.activatedRoute.queryParams,
      (data, params, queryParams) => ({ data: { ...data }, params: { ...params }, query: { ...queryParams } })
    );

    urlParams.subscribe(routeParams => {
      this.store.dispatch(FormsActions.startNewForm({ access: routeParams.data.type, key: routeParams.params.key, prefill: routeParams.query }));
    });
  }

}
