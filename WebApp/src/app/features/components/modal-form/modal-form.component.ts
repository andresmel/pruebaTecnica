import { EmployeesService } from './../../../core/services/employees.service';
import { Component,Output,Input,SimpleChanges} from '@angular/core';
import { EventEmitter } from '@angular/core';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core'; // Necesario para el datepicker con fechas nativas
import { MatIconModule } from '@angular/material/icon';
import { ProductsService } from '../../../core/services/products.service';
import { ShippersService } from '../../../core/services/shippers.service';
import { OrdersService } from '../../../core/services/orders.service';
import { error } from 'console';
@Component({
  selector: 'app-modal-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    CommonModule],
  templateUrl: './modal-form.component.html',
  styleUrl: './modal-form.component.css'
})
export class ModalFormComponent {
   @Input() predictionObg:any=[];
   @Output() modalForm = new EventEmitter<any>();
   orderForm: FormGroup;


  employees:any;
  shippers:any;
  products:any;


  constructor(private fb: FormBuilder,private _employeeService:EmployeesService,private _productService:ProductsService,private _shipperService:ShippersService,private _orderService:OrdersService) {
    this.orderForm = this.fb.group({
      custid:[''],
      employee: ['', Validators.required],
      shipper: ['', Validators.required],
      shipName: ['', Validators.required],
      shipAddress: ['', Validators.required],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: ['', Validators.required],
      freight: ['', Validators.required],
      product: ['', Validators.required],
      unitPrice: ['', Validators.required],
      quantity: ['', Validators.required],
      discount: ['', Validators.required],
    });
    this.employees=[];
    this.products=[];
    this.shippers=[];
  }


  ngOnInit(): void {
    this.getEmployyes();
    this.getProductos();
    this.getShippers();
  }

  ngOnChanges(changes: SimpleChanges){

    if (changes['predictionObg'] && this.predictionObg?.custid) {
      this.orderForm.patchValue({
        custid: this.predictionObg.custid
      });

    }
  }

  onSubmit() {
    if (this.orderForm.valid) {
      this.orderForm.value.requiredDate=this.orderForm.value.requiredDate.toISOString().split('T')[0];
      this.orderForm.value.orderDate=this.orderForm.value.orderDate.toISOString().split('T')[0];
      this.orderForm.value.shippedDate=this.orderForm.value.shippedDate.toISOString().split('T')[0];
      this._orderService.postOrder(this.orderForm.value).subscribe((datos:any)=>{
        this.orderForm.reset();
        Swal.fire({
          position: "center",
          icon: "success",
          title: "Order success !!",
          showConfirmButton: false,
          timer: 1500
        })
    },(error:any)=>{
      Swal.fire({
        position: "center",
        icon: "success",
        title: "discount exceded, max value 9.999",
        showConfirmButton: false,
        timer: 2500
      })
      this.orderForm.reset();
    })
    }else{
      Swal.fire("please complete all fields *");
    }

  }


  getEmployyes(){
     this._employeeService.getEmployees().subscribe((datos:any)=>{
      this.employees=datos.data;
     })
  }
  getShippers(){
     this._shipperService.getShippers().subscribe((datos:any)=>{
      this.shippers=datos.data;
     })
  }
  getProductos(){
      this._productService.getProducts().subscribe((datos:any)=>{
        this.products=datos.data;
      })
  }

  cerrarModal(){
    this.modalForm.emit(false);
  }
}
