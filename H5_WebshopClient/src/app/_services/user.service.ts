import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = environment.apiUrl + '/User';
  apiUrl1 = environment.apiUrl + '/User/register';
  apiUrl2 = environment.apiUrl + '/User/guestRegister';


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private http: HttpClient
  ) { }

  public getRole: BehaviorSubject<number> = new BehaviorSubject(0);
  public getRole$: Observable<number> = this.getRole.asObservable();


  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl)
  }

  getRole_(roleNr: number) {
    this.getRole.next(roleNr)
  }
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl1, user, this.httpOptions);
  }
  guest_register(guestUser: User): Observable<User>{
    return this.http.post<User>(this.apiUrl2, guestUser, this.httpOptions);
  }
  getUserbyUserName(userName:string):Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${userName}`);;
  }
  updateUser(userId: number, user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/${userId}`, user, this.httpOptions);
  }

  deleteUser(userId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${userId}`, this.httpOptions);
  }
}
