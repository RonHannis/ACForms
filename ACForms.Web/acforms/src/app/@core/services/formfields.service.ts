import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { first, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FormfieldsService {

  _isUsernameAvailable = new Subject<boolean>();
  IsUsernameAvailable = this._isUsernameAvailable.asObservable();

  checkUsernameIsAvailable(username: string): void {
     this.http.get<boolean>(`/api/account/provider/username-is-available/${username}`).subscribe(r => this._isUsernameAvailable.next(r));
  }

  usernameValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.IsUsernameAvailable.pipe(
        map(available => {
          return available == false ? { usernameExists: true } : null;
        })
      ).pipe(first());
    };
  }


  constructor(
    private http: HttpClient
  ) { }
}
