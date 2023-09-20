import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomerService } from '../service/customer.service';
import { ResponseDTO } from 'src/app/core/Models/ResponseDTO';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {}

  listCustomers: ResponseDTO[] = [];

  displayedColumns: string[] = [
    'CompanyName',
    'ContactName',
    'Address',
    'Phone',
    'Delete',
  ];

  dataSource: any;

  // @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.getCustomers();
  }

  // ngAfterViewInit() {
  //   this.dataSource.paginator = this.paginator;
  // }

  redirectToAdd() {
    this.router.navigate(['/addcustomer']);
  }

  redirectToModify() {
    this.router.navigate(['/modifyphone']);
  }

  delete(id: string) {
    this.customerService.deleteCustomer(id).subscribe((data) => {});
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe((response) => {
      if (response != null) {
        this.listCustomers = response as unknown as ResponseDTO[];
        this.dataSource = new MatTableDataSource<any>(this.listCustomers);
      } 
      if (this.listCustomers.length === 0) {
        alert('OCURRIO UN ERROR AL CONECTARSE CON EN SERVIDOR');
      }
    });
  }
}
