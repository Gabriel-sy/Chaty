import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ChatComponent } from "../chat/chat.component";
import { UserService } from '../../../services/user.service';
import { Observable, Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ChatService } from '../../../services/chat.service';
import { ChatViewModel } from '../../../models/ChatViewModel';
import { SearchResultsModel } from '../../../models/SearchResultsModel';
import { UserViewModel } from '../../../models/UserViewModel';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ChatComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent implements OnInit {
  searchResults: SearchResultsModel[] = [];
  userNames: string[] = [];
  userChats$: Observable<ChatViewModel[]> = new Observable<ChatViewModel[]>();
  isLoading: boolean = false;
  isSent: boolean = false;
  requests: string[] = [];
  notificationDisplay: boolean = false;


  constructor(
    private userService: UserService,
    private chatService: ChatService){
  }

  ngOnInit(): void {
    this.userChats$ = this.chatService.getAllUserChats()
    this.userService.getUser()
    .subscribe({
      next: (res: UserViewModel) => {
        this.requests = res.chatRequests;
        console.log(this.requests)
      }
    })
  }

  onSearchInput(event: Event): void {
    const query = (event.target as HTMLInputElement).value;
    if (query) {
      this.searchUsers(query);
    } else {
      this.searchResults = [];
    }
  }

  searchUsers(query: string): void {
    this.userService.searchUsers(query).subscribe({
      next: (res: SearchResultsModel[]) => {
        this.searchResults = res;
        console.log(this.searchResults)
        console.log(res)
      },
      error: (err) => {
        console.error('Erro ao buscar usuários:', err);
      }
    });
  }

  sendChatRequest(user: SearchResultsModel){
    user.isLoading = true;
    this.userService.sendChatRequest(user.userName).subscribe({
      next: (res) => {
        user.isLoading = false;
        user.isSent = true;
      },
      error: (err) => {
        user.isLoading = false;
      }
    });

  }
}
