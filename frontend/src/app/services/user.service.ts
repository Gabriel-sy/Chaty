import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchResultsModel } from '../models/SearchResultsModel';
import { UserViewModel } from '../models/UserViewModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly API = "http://localhost:5034/api/user";

  constructor(private http: HttpClient) { }

  searchUsers(query: string){
    return this.http.get<SearchResultsModel[]>(this.API + "/search?query=" + query);
  }

  sendChatRequest(receiver: string){
    return this.http.get(this.API + "/chat?receiver=" + receiver);
  }

  getUser(){
    return this.http.get<UserViewModel>(this.API)
  }
}
