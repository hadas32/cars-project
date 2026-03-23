import { Component, Input } from '@angular/core';
import { CarsComponent } from '../cars/cars.component';
import { Car, CarService } from '../service/car.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { customer } from '../service/customer.service';
import { Rent, RentService } from '../service/rent.service'; // ייבוא RentService
import { PaymentService } from '../service/payment.service'; // ייבוא PaymentService

@Component({
  selector: 'app-display-cars',
  standalone: true,
  imports: [CarsComponent, CommonModule, FormsModule],
  templateUrl: './display-cars.component.html',
  styleUrl: './display-cars.component.css'
})
export class DisplayCarsComponent {
  @Input() user: customer | null = null; 

  arr: Car[] = [];
  filteredArr: Car[] = []; // המערך החדש שיוצג בפועל על המסך

  // משתנים לשמירת ערכי הסינון שהמשתמש מקליד
  filterSeats: number | null = null;
  filterLevel: number | null = null;
  maxPrice: number | null = null;

  selectedCar: Car | null = null;

  rentModel: Rent = {
    codeCar: 0,
    codeCustomer: 0,
    startDate: new Date(),
    endDate: new Date(),
    goal: ''
  };

  paymentModel = {
    creaditCard: '',
    validity: '',
    cvc: null
  };

constructor(
    private service: CarService,
    private rentService: RentService,
    private paymentService: PaymentService
  ) {
    this.service.getCarsList().subscribe(data => {
      this.arr = data;
      this.filteredArr = data; // בהתחלה, המערך המסונן זהה למערך המלא
    });
  }

  applyFilters() {
    this.filteredArr = this.arr.filter(car => {
      let isMatch = true;

      // אם המשתמש הזין מספר מושבים, והרכב לא תואם -> תפסול אותו
      if (this.filterSeats && car.numSeats !== this.filterSeats) {
        isMatch = false;
      }
      // אם המשתמש הזין רמה, והרכב לא תואם -> תפסול אותו
      if (this.filterLevel && car.level !== this.filterLevel) {
        isMatch = false;
      }
      // אם המשתמש הזין מחיר מקסימלי, והרכב יקר יותר -> תפסול אותו
      if (this.maxPrice && car.priceForDay > this.maxPrice) {
        isMatch = false;
      }

      return isMatch; // רק רכבים שעברו את כל הבדיקות יישארו
    });
  }
  // פונקציה לניקוי כל הסינונים
  clearFilters() {
    this.filterSeats = null;
    this.filterLevel = null;
    this.maxPrice = null;
    this.filteredArr = this.arr; // מחזירים את כל הרכבים
  }

  onCarPicked(car: Car) {
    this.selectedCar = car;
    this.rentModel.codeCar = car.code;
    if (this.user && this.user.Id) {
      this.rentModel.codeCustomer = this.user.Id;
    }
  }

  // הפונקציה המעודכנת ששומרת מול השרת!
  onSubmitRent() {
    // 1. קודם כל שולחים את התשלום לשרת
    this.paymentService.addPayment(this.paymentModel).subscribe({
      next: (paymentResponse) => {
        console.log("תשובה משמירת תשלום:", paymentResponse);

        // 2. רק אם התשלום הצליח - שולחים את ההשכרה!
        this.rentService.addRent(this.rentModel).subscribe({
          next: (rentResponse) => {
            console.log("תשובה משמירת השכרה:", rentResponse);
            alert("מזל טוב! הרכב הושכר בהצלחה.");
            
            // מנקים את הבחירה כדי להחזיר את המשתמש לרשימת הרכבים
            this.selectedCar = null;
          },
          error: (rentErr) => {
            console.error("שגיאה בשמירת ההשכרה:", rentErr);
            alert("התשלום עבר, אך אירעה שגיאה בשמירת ההשכרה.");
          }
        });

      },
      error: (paymentErr) => {
        console.error("שגיאה בשמירת תשלום:", paymentErr);
        alert("אירעה שגיאה בביצוע התשלום. אנא בדוק את פרטי האשראי.");
      }
    });
  }
}