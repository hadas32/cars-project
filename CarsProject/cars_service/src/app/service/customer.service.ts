import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// הגדרת המבנה של עיר (בדיוק כמו ה-DTO בשרת)
export interface City {
  code: number;
  name: string;
}

export interface customer {
  Id?: number;
  firstName: string;
  lastName: string;
  codeCity: number | null;     
  email: string;
  password: string;
  numRents: number;
  codePayment: number | null; 
  address: string;
}

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  // כתובת בסיס ללקוחות
  urlCustomer = "http://localhost:53191/api/customer"; 
  // כתובת בסיס לערים - שימי לב שזה תואם לקונטרולר ששלחת
  urlCity = "http://localhost:53191/api/city"; 

  constructor(private http: HttpClient) { }

  register(newCustomer: customer): Observable<string> {
    return this.http.post<string>(`${this.urlCustomer}/insertclient`, newCustomer);
  }

  login(email: string, pass: string): Observable<customer> {
    return this.http.get<customer>(`${this.urlCustomer}/login?email=${email}&password=${pass}`);
  }

  // --- הפונקציה החדשה להבאת ערים ---
  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(`${this.urlCity}/getallcities`);
  }


  updateCustomer(updatedCustomer: customer): Observable<number> {
    return this.http.put<number>(`${this.urlCustomer}/updateclient`, updatedCustomer);
  }
}