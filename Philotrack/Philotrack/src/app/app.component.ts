import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public siglums?: Siglum[];
  public forecasts?: WeatherForecast[];
  address = 'pepillo';
  constructor(http: HttpClient) {
    this.address = "test";
    http.get<Siglum[]>('/api/siglums').subscribe(result => {
      this.siglums = result;
    }, error => console.error(error));
  }
  //title = 'Philotrack2';
}

interface Siglum {
  Id: number;
  Code: string | null;
  Name: string | null;
}

interface WeatherForecast {
  Summary: string;
  TemperatureC: number;
}
