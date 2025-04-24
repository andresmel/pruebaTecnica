import { AfterViewInit, Component, ViewChild, Input, OnChanges, SimpleChanges, Output ,EventEmitter, input, output} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CommonModule, DatePipe } from '@angular/common';


@Component({
  selector: 'app-table',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule,CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css',
  providers:[DatePipe]
})
export class TableComponent implements AfterViewInit, OnChanges{
   @Input() displayedColumns?:string[];
   @Input() costumersOrders?:any[];
   @Input() filterData?:any[];
   @Output() costumer = new EventEmitter<any>();
   @Output() costumerForm = new EventEmitter<any>();


   dataSource = new MatTableDataSource<any>([]);
   @ViewChild(MatPaginator) paginator!: MatPaginator;
   @ViewChild(MatSort) sort!: MatSort;

   constructor(){}

   ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
   }

   ngOnChanges(changes: SimpleChanges) {
    if (changes['costumersOrders'] && this.costumersOrders) {
      this.dataSource.data = this.costumersOrders;
    }

    if(changes['filterData'] && this.filterData){
      this.dataSource.data=this.filterData;
    }
  }

  viewOrder(element:any){
     this.costumer.emit(element);
  }
  newOrder(element:any){
    this.costumerForm.emit(element);
  }

}
