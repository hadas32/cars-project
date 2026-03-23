import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Rent {
   code?: number;
   codeCustomer:number;
   codeCar: number;
   startDate: Date;
   endDate: Date;
   goal?: string;
   cars?: any;
   customers?: any;
}

@Injectable({
  providedIn: 'root'
})
export class RentService {
  urlRent = "http://localhost:53191/api/rent";
  constructor(private http: HttpClient) { }

  getRentHistoryByCustomerId(customerId: number): Observable<Rent[]> {
    return this.http.get<Rent[]>(`${this.urlRent}/getrentbycustomerid/${customerId}`);
  }

  addRent(newRent: Rent): Observable<any> {
    // גם כאן השרת מחזיר מחרוזת
    return this.http.post(`${this.urlRent}/insertrent/rent`, newRent, { responseType: 'text' });
  }
}

