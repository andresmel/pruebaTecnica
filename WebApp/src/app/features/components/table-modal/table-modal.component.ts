import { Component,Input,OnChanges,SimpleChanges } from '@angular/core';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CommonModule, DatePipe } from '@angular/common';
@Component({
  selector: 'app-table-modal',
  standalone: true,
  imports: [MatTableModule,MatPaginatorModule,MatSortModule,CommonModule],
  templateUrl: './table-modal.component.html',
  styleUrl: './table-modal.component.css'
})
export class TableModalComponent {
@Input() displayedColumnsModal?:string[];
@Input() ordersbyCustomers?:any=[];

dataSource = new MatTableDataSource<any>([]);
@ViewChild(MatPaginator) paginator!: MatPaginator;
@ViewChild(MatSort) sort!: MatSort;
constructor(){
}

ngAfterViewInit() {
  this.dataSource.paginator = this.paginator;
  this.dataSource.sort = this.sort;
}

ngOnChanges(changes: SimpleChanges) {
  if (changes['ordersbyCustomers'] && this.ordersbyCustomers) {
    this.dataSource.data = this.ordersbyCustomers.data;
  }
}

}
