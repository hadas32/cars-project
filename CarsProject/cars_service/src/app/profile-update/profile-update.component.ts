import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { City, customer, CustomerService } from '../service/customer.service';

@Component({
  selector: 'app-profile-update',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile-update.component.html',
  styleUrl: './profile-update.component.css'
})
export class ProfileUpdateComponent implements OnInit{
  @Input() user: customer | null = null;
  cities: City[] = [];
  editedUser: customer = {} as customer;
  message: string = '';
  constructor(private custService: CustomerService) {}

  ngOnInit(): void {

    this.custService.getAllCities().subscribe({
      next: (res) => this.cities = res,
      error: (err) => console.error("שגיאה בהבאת ערים:", err)
    });

    if (this.user) {
      this.editedUser = { ...this.user }; 
    }
  }

  onSubmit() {
    this.custService.updateCustomer(this.editedUser).subscribe({
      next: (res) => {

        if (res > 0) {
          this.message = "הפרטים עודכנו בהצלחה!";

          if (this.user) {
            Object.assign(this.user, this.editedUser);
          }
        } else {
          this.message = "לא בוצע עדכון. ייתכן שהפרטים זהים.";
        }
      },
      error: (err) => {
        console.error("שגיאה בעדכון:", err);
        this.message = "אירעה שגיאה בעדכון הפרטים.";
      }
    });
  }
}
