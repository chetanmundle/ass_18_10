import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css',
})
export class CustomerComponent {
  customerFormData: FormGroup = new FormGroup({
    customerId: new FormControl(0),
    firstName: new FormControl('', [Validators.required]),
    middleName: new FormControl(''),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('@gmail.com', [
      Validators.required,
      Validators.email,
    ]),
    phone: new FormControl('', [Validators.required]),
    gender: new FormControl('', [Validators.required]),
    addressLine1: new FormControl('', [Validators.required]),
    addressLine2: new FormControl(''),
    city: new FormControl('', [Validators.required]),
    state: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required]),
    zipCode: new FormControl('', [Validators.required]),
    dateOfBirth: new FormControl('', [Validators.required]),
    occupation: new FormControl(''),
    company: new FormControl(''),
    department: new FormControl(''),
    createdDate: new FormControl(),
    updatedDate: new FormControl(),
    isDeleted: new FormControl(false),
  });
}
