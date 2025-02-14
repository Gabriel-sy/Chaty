import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly API = "http://localhost:5034/api/user";

  constructor(private http: HttpClient) { }

  searchUsers(query: string){
    return this.http.get<string[]>(this.API + "/search?query=" + query);
  }
}
