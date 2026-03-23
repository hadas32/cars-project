import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // חשוב ל-ngIf
import { LoginComponent } from './login/login.component';
import { DisplayCarsComponent } from './display-cars/display-cars.component';
import { customer } from './service/customer.service';
import { RentalHistoryComponent } from "./rental-history/rental-history.component";
import { ProfileUpdateComponent } from "./profile-update/profile-update.component";
import { AboutComponent } from "./about/about.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, LoginComponent, DisplayCarsComponent, RentalHistoryComponent, ProfileUpdateComponent, AboutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  currentTab: string = 'history';
  title = 'cars_service';
  
  // משתנה שמחזיק את המשתמש המחובר (בהתחלה הוא ריק)
  currentUser: customer | null = null;
  // פונקציה שתקרא כשהמשתמש מתחבר בהצלחה
  onUserLogin(user: customer) {
    console.log("משתמש התחבר:", user);
    this.currentUser = user;
    this.currentTab = 'history';
  }

  switchTab(tabName: string) {
    this.currentTab = tabName;
  }
}