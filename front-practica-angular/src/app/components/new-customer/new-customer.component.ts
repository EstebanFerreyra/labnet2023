import { Component } from '@angular/core';

import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomerService } from '../service/customer.service';
import { NewCustomerI } from 'src/app/core/Models/NewCustomer.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-customer',
  templateUrl: './new-customer.component.html',
  styleUrls: ['./new-customer.component.css'],
})
export class NewCustomerComponent {
  newCustomer = new FormGroup({
    CustomerID: new FormControl('', Validators.required),
    CompanyName: new FormControl('', Validators.required),
    ContactName: new FormControl('', Validators.required),
    Address: new FormControl('', Validators.required),
    Phone: new FormControl('', Validators.required),
  });

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {}

  redirectToHome() {
    this.router.navigate(['/home']);
  }
  
  onNewCustomer(form: any) {
    console.log(form);
    if (
      form.CompanyName != '' &&
      form.ContactName != '' &&
      form.Address != '' &&
      form.Phone != ''
    ) {
      this.customerService.addCustomer(form).subscribe((response) => {
        if (response.success == true) {
          alert('CLIENTE AGREGADO CON EXITO');
          this.redirectToHome();
        } else {
          alert('ERROR AL AGREGAR CLIENTE - REINTENTAR');
        }
      });
    } else {
      alert('COMPLETE TODOS LOS CAMPOS');
    }
  }
}
