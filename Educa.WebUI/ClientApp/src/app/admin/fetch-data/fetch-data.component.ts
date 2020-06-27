import { Component, Inject } from '@angular/core';
import { IWeatherForecast, WeatherForecastClient } from '../../EducaDotNet-api';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: IWeatherForecast[];

  constructor(client: WeatherForecastClient) {
    client.get().subscribe(response =>
    {
      this.forecasts = response;
    })
  }
}

