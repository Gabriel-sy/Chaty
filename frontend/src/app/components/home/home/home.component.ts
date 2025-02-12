import { Component, ViewEncapsulation } from '@angular/core';
import { ChatComponent } from "../chat/chat.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ChatComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent {

}
