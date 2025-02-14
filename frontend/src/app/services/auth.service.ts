import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginInputModel } from '../models/LoginInputModel';
import { JwtResponse } from '../models/JwtResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly API = "http://localhost:5034/api/auth";

  constructor(private http: HttpClient) { }

  registerUser(username: string, email: string, password: string, biography?: string){
    var objectToSend = {
      email: email,
      password: password,
      userName: username,
      biography: biography ?? ""
    }
    
    return this.http.post(this.API + "/register", objectToSend);
  }

  login(email: string, password: string){
    var objectToSend = {
      email: email,
      password: password
    }
    
    return this.http.post<JwtResponse>(this.API + "/login", objectToSend);
  }
}
