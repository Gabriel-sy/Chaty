import { Component, ViewEncapsulation } from '@angular/core';
import { ChatComponent } from "../chat/chat.component";
import { UserService } from '../../../services/user.service';
import { Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ChatComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent {
  searchResults: any[] = [];
  userNames: string[] = [];

  constructor(private userService: UserService){
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
      next: (res) => {
        this.searchResults = res;
        console.log(this.searchResults)
      },
      error: (err) => {
        console.error('Erro ao buscar usuários:', err);
      }
    });
  }
}
