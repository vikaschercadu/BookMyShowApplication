import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';
@Injectable({
  providedIn: 'root'
})
export class CityService {
  cities: City[] = [];
  cityChosenId!: number;
  private apiUrl = 'https://localhost:44371/api/City';
  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  getCities(): Observable<City[]>{
    console.log((this.httpClient.get<City[]>(this.apiUrl)));
    return this.httpClient.get<City[]>(this.apiUrl);
  }

  setCityId(city: number){
    this.cityChosenId = city;
  }

  getCityId(){
    return this.cityChosenId;
  }
}
