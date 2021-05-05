import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { City } from '../models/city.model';
import { CityService } from '../services/city.service';
@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.scss']
})
export class CityComponent implements OnInit {

  cities!: City[];
  city: City = new City({});
  cityId!: number;

  constructor(public cityService: CityService, public router: Router) { }

  ngOnInit(): void {
    this.cityService.getCities().subscribe(res => {
      this.cities = res;
    });
  }
  selected() {
		this.cityService.setCityId(this.cityId);
		this.router.navigate(['movies']);
	}

}
