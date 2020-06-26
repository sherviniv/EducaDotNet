import { Injectable } from '@angular/core';
import { AccountClient, LoginDto } from '../../EducaDotNet-api';
import { User } from '../models';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private client: AccountClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(model: LoginDto) {
    return this.client.login(model).pipe(map(response => {
      if (response && response.succeeded) {

        const user = this.decodeJWT(response.data);
        user.token = response.data;
        user.roles = JSON.parse(user.roles);
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
      }
    }));
  }

  private decodeJWT(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
