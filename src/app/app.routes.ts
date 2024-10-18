import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CustomerComponent } from './Components/customer/customer.component';
import { EmployeeComponent } from './Components/employee/employee.component';
import { PatientComponent } from './Components/patient/patient.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'patient', component: PatientComponent },
];
