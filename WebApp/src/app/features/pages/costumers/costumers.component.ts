import { Component } from '@angular/core';
import { TableComponent } from '../../components/table/table.component';
import { SearchComponent } from "../../components/search/search.component";
import { CostumersService } from '../../../core/services/costumers.service';
import { ModalComponent } from '../../components/modal/modal.component';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { ModalFormComponent } from '../../components/modal-form/modal-form.component';

@Component({
  selector: 'app-costumers',
  standalone: true,
  imports: [TableComponent, SearchComponent,CommonModule,ModalComponent,RouterModule,ModalFormComponent],
  templateUrl: './costumers.component.html',
  styleUrl: './costumers.component.css'
})
export class CostumersComponent {
  predictionObg:any;
  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder','red','green'];
  displayedColumnsModal:string[]=['orderid','requireddate','shippeddate','shipname','shipaddress','shipcity']
  costumersOtrders:any;
  ordersbyCustomers:any;
  showModal:boolean;
  showModalForm:boolean;
  obj:any;
  filterData:any;
  constructor(private _service:CostumersService){
    this.costumersOtrders=[];
    this.ordersbyCustomers=[];
    this.showModal=false;
    this.obj={custid:0,CustomerName:"",LastOrderDate:null,NextPredictedOrder:null}
    this.filterData=[];
    this.showModalForm=false;
    this.predictionObg=[];
  }

   ngOnInit(): void {
       this.getCostumers();
   }

  getCostumers(){
    this._service.getCostumers().subscribe((data:any)=>{
      this.costumersOtrders=data.data;
    })
  }

  HandleCostumer(customer:any){
    this.showModal=true;
    this._service.getOrderByCostumer(customer).subscribe((datos)=>{
      this.ordersbyCustomers=datos;
    })
  }

  HandleFormCostumer(customer:any){
    this.showModalForm=true;
    this.predictionObg=customer;
     console.log(customer);
  }

  handleModal(close:boolean){
     this.showModal=close;
  }

  HandleModalForm(close:boolean){
     this.showModalForm=close;
  }

  handleGetName(text:String){
    this.obj.CustomerName=text;
    console.log(this.obj)
    this._service.getFilterbyCustomerName(this.obj).subscribe((datos:any)=>{
     this.filterData=datos.data;
    })
  }

}
