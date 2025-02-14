import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChatViewModel } from '../models/ChatViewModel';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private readonly API = "http://localhost:5034/api/chat";

  constructor(private http: HttpClient) { }

  getAllUserChats(){
    return this.http.get<ChatViewModel[]>(this.API)
  }
}
