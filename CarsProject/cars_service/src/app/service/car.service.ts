import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface Car{
  code:number
  numSeats:number
  level:number
  priceForDay:number
  priceForThreeDaysAndMor:number
}
@Injectable({
  providedIn: 'root'
})
export class CarService {
  url="http://localhost:53191/api/car"
  constructor(private http:HttpClient) { }
  getCarsList ():Observable<Car[]>{
    return this.http.get<Car[]>(this.url+"/getallcars")
  }
  // getAvaliableCar(){}
}
