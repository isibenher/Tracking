import { Component } from '@angular/core';
import { ViewChild} from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild(MatSidenav) sidenav: MatSidenav;
  events: string[] = [];
  opened: boolean = false;

}
