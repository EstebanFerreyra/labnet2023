import { Injectable } from '@angular/core';
import { environment } from 'src/app/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, ObservedValueOf } from 'rxjs';

import { ResponseDTO } from 'src/app/core/Models/ResponseDTO';
import { NewCustomerI } from 'src/app/core/Models/NewCustomer.interface';
import { ResponsePostI } from 'src/app/core/Models/ResponsePost.interface';
import { ModifyPhoneI } from 'src/app/core/Models/ModifyPhoneI.interface';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiUrl: string = environment.apiLab;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
  };
  constructor(private http: HttpClient) {}

  getCustomers(): Observable<ResponseDTO> {
    let url: string = `${this.apiUrl}Api/Customers/Get`;
    return this.http.get<ResponseDTO>(url);
  }

  addCustomer(form: NewCustomerI): Observable<ResponsePostI> {
    let url: string = `${this.apiUrl}Api/Customers/AddCustomer`;
    return this.http.post<ResponsePostI>(url, form, this.httpOptions);
  }

  modifyPhone(form: ModifyPhoneI): Observable<ResponsePostI> {
    let url: string = `${this.apiUrl}Api/Customers/UpdatePhone`;
    return this.http.patch<ResponsePostI>(url, form, this.httpOptions);
  }

  deleteCustomer(id: string): Observable<ResponsePostI>{
    let url: string = `${this.apiUrl}Api/Customers/delete?id=${id}`;
    let Options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      }),
    };
    return this.http.delete<ResponsePostI>(url, Options);
  }
}
