import { Component, OnInit, Output, EventEmitter } from '@angular/core'; // 1. הוספנו Output, EventEmitter
import { CustomerService, customer, City } from '../service/customer.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  isLoginMode = true;
  cities: City[] = [];

  // 2. יצירת ה"רמקול" שמשדר לאבא כשההתחברות הצליחה
  @Output() loginSuccess = new EventEmitter<customer>();

  userModel: customer = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    address: '',
    codeCity: null,
    numRents: 0,
    codePayment: null
  };

  constructor(private custService: CustomerService, private router: Router) { }

  ngOnInit(): void {
    this.custService.getAllCities().subscribe({
      next: (res) => {
        this.cities = res;
      },
      error: (err) => console.error("שגיאה בטעינת ערים:", err)
    });
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  onSubmit() {
    if (this.isLoginMode) {
        // --- התחברות ---
        this.custService.login(this.userModel.email, this.userModel.password).subscribe({
            next: (res) => {
                if (res) {
                   this.loginSuccess.emit(res); 
                }
                else {
                    alert("פרטים שגויים, נסה שוב.");
                }
            }, 
            error: (err) => console.log(err)
        });
    } 
    else {
      // --- הרשמה ---
      console.log("שולח להרשמה:", this.userModel);

      this.custService.register(this.userModel).subscribe({
        next: (res) => {
           if (res && res.toString().includes("error")) {
               alert("שגיאה מהשרת: " + res);
           } else {
               alert('נרשמת בהצלחה! כעת נא להתחבר.');
               this.isLoginMode = true; // מעביר למצב התחברות
           }
        },
        error: (err) => {
          console.error('שגיאה בתקשורת', err);
          alert('אירעה שגיאה בתקשורת');
        }
      });
    }
  }
}