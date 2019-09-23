import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../model/country.model';
import { State } from '../model/state.model';
import { City } from '../model/city.model';


@Injectable({
  providedIn: 'root'
})
export class CommonService {



  readonly url = 'https://localhost:44388/Api';
  listCountry: Country[];
  listState: State[];
  listCity: City[];
  constructor(private http: HttpClient) { }


  CountryList() {
     return this.http.get(this.url + '/Country/GetCountries');
  }

  
  CityByCountry(countryCode: string) {
    return this.http.get(this.url + '/Country/GetCitiesByCountry?countryCode=' + countryCode);
  }

  GetWeatherDetails(cityId:number){
    return this.http.get(this.url + '/Weather/GetWeather?CityId=' + cityId);

  }
}
