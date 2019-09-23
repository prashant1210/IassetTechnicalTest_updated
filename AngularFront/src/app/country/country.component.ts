import { Component, OnInit } from '@angular/core';
import { CommonService } from '../shared/common.service';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {
  country_List: any;
  cityList: any;
  country: any;
  city: any;
  showWeather: boolean;
  weather: Object;
  showError: boolean;
  constructor(private service: CommonService) {

  }

  async ngOnInit() {
    debugger;

    try {
      this.showWeather = false;
      this.country_List = await this.service.CountryList().toPromise();
      debugger;
      this.showError = false;
    } catch (error) {
      if (error.status == 500) {
        this.showError = true;
        this.showWeather = false;
      }
    }

  }
  async BindCity(countryId: string) {

    debugger;

    this.showWeather = false;
    if (countryId !== "undefined") {
      try {
        this.city = "undefined";
        this.cityList = [];
        this.cityList = await this.service.CityByCountry(countryId).toPromise();
        this.showError = false;

      } catch (error) {
        this.showError = true;
        this.showWeather = false;



      }
    }
    else {
      this.city = "undefined";
      this.cityList = [];
    }



  }

  ChangedCity(value){
this.showWeather= false;
  }


  async GetWeather() {
    debugger;

    if (this.country != undefined && this.city != undefined && this.country !== "undefined" && this.city !== "undefined") {
      console.log(this.city);


      try {
        this.weather = await this.service.GetWeatherDetails(this.city).toPromise();
        this.showWeather = true;
      } catch (error) {
        if (error.status == 500) {
          this.showError = true;
          this.showWeather = false;
        }
      }

    }
    else {
      this.showWeather = false;
      alert("Please Select city and country");
    }
  }




}
