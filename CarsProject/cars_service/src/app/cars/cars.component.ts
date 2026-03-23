import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { Car } from '../service/car.service';

@Component({
  selector: 'app-cars',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './cars.component.html',
  styleUrl: './cars.component.css'
})
export class CarsComponent {
  // המשתנה הזה יקבל את המידע מהרכיב אבא
  @Input() car: Car | any;
  @Output() carSelected = new EventEmitter<Car>();

  onSelectCar() {
    this.carSelected.emit(this.car);
  }
}