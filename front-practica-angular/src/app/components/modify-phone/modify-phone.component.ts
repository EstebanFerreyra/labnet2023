import { Component } from '@angular/core';
import { CustomerService } from '../service/customer.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-modify-phone',
  templateUrl: './modify-phone.component.html',
  styleUrls: ['./modify-phone.component.css'],
})
export class ModifyPhoneComponent {
  modifyPhoneForm = new FormGroup({
    CustomerID: new FormControl('', Validators.required),
    Phone: new FormControl('', Validators.required),
  });

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {}

  redirectToHome() {
    this.router.navigate(['/home']);
  }

  onModifyPhone(form: any) {
    console.log(form)
    if (form.CustomerID != '' && form.Phone != '') {
      this.customerService.modifyPhone(form).subscribe((response) => {
        if (response.success == true) {
          alert('CLIENTE MODIFICADO CON EXITO');
          this.redirectToHome();
        } else {
          alert('ERROR AL MODIFICAR CLIENTE - REINTENTAR');
        }
      });
    } else {
      alert('COMPLETE TODOS LOS CAMPOS');
    }
  }

}
