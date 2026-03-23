import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Payment {
  code?: number;
  creaditCard: string;
  validity: string;
  cvc: number | null;
}

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  urlPayment = "http://localhost:53191/api/payment";

  constructor(private http: HttpClient) { }
  
  addPayment(newPayment: Payment): Observable<any> {
   
    return this.http.post(`${this.urlPayment}/insertpayment/payment`, newPayment, { responseType: 'text' });
  }
}
