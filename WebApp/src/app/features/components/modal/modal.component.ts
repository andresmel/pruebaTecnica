import { Component, Output ,Input} from '@angular/core';
import { EventEmitter } from '@angular/core';
import { TableModalComponent } from "../table-modal/table-modal.component";


@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [TableModalComponent],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @Output() modal = new EventEmitter<any>();
  @Input() displayedColumnsModal:any=[];
  @Input() ordersbyCustomers:any=[];
  @Input() predictionObg:any=[];
  constructor(){}

  cerrarModal(){
     this.modal.emit(false);
  }
}
