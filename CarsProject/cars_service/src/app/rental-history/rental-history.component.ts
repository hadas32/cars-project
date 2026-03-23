import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Rent, RentService } from '../service/rent.service';
import { customer } from '../service/customer.service';

@Component({
  selector: 'app-rental-history',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './rental-history.component.html',
  styleUrl: './rental-history.component.css'
})
export class RentalHistoryComponent implements OnInit {
  @Input() user: customer | null = null;
  rents: Rent[] = [];
  constructor(private rentService: RentService) {}
  ngOnInit(): void {

    if (this.user && this.user.Id) {
      this.rentService.getRentHistoryByCustomerId(this.user.Id).subscribe({
        next: (res) => {
          this.rents = res; 
        },
        error: (err) => console.error("שגיאה בהבאת היסטורית השכרות:", err)
      });
    }
  }

}
