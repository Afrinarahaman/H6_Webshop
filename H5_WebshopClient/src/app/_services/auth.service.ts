import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../_models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Role } from '../_models/role';

@Injectable({
  providedIn: 'root'
})
export class AuthService { 
  private currentMemberSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    // fake login durring testing
    // if (sessionStorage.getItem('currentUser') == null) {
    //   sessionStorage.setItem('currentUser', JSON.stringify({ id: 0, email: '', customername: '', role: null }));
    // }
    this.currentMemberSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentMember') as string));
    this.currentUser = this.currentMemberSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentMemberSubject.value;
  }

  login(email: string, password: string) {
    return this.http.post<any>(`${environment.apiUrl}/User/authenticate`, { email, password })
      .pipe(map((user: User) => {
        // store customer details and jwt token in local storage to keep customer logged in between page refreshes
        sessionStorage.setItem('currentMember', JSON.stringify(user));
        
        this.currentMemberSubject.next(user);
        // console.log('login customer',customer);
        return user;
      }));
  }

  /*logout() {
    // remove customer from local storage to log customer out
    sessionStorage.removeItem('currentMember');
    // reset CurrentUserSubject, by fetching the value in sessionStorage, which is null at this point
    //this.currentMemberSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentMember') as string));
    // reset CurrentUser to the resat UserSubject, as an obserable
    //this.currentUser = this.currentMemberSubject.asObservable();
    this.currentMemberSubject.next(null);
  }*/
  logout() {
    // remove user from local storage to log user out
    sessionStorage.removeItem('currentMember');
    // reset CurrentUserSubject, by fetching the value in sessionStorage, which is null at this point
    this.currentMemberSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentMember') as string));
    // reset CurrentUser to the resat UserSubject, as an obserable
    this.currentUser = this.currentMemberSubject.asObservable();
    
  }

 register(email: string, password: string, firstName: string, LastName: string, address: string, telephone: string) {
    return this.http.post<any>(`${environment.apiUrl}/User/authenticate`, { email, password, firstName, LastName, address, telephone})
      .pipe(map(user => {
        // store customer details and jwt token in local storage to keep customer logged in between page refreshes
        sessionStorage.setItem('currentMember', JSON.stringify(user));
        this.currentMemberSubject.next(user);
        // console.log('login customer',customer);
        return user;
      }));
  }
  register_guest(email: string, password: string, firstName: string, LastName: string, address: string, telephone: string) {
    return this.http.post<any>(`${environment.apiUrl}/User/guestRegister`, {  firstName, LastName, address, telephone, email})
      .pipe(map(user => {
        // store customer details and jwt token in local storage to keep customer logged in between page refreshes
        sessionStorage.setItem('guest', JSON.stringify(user));
        this.currentMemberSubject.next(user);
        // console.log('login customer',customer);
        return user;
      }));
  }

}
