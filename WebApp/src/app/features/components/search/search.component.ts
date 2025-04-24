import { Component, Output } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [FormsModule,MatInputModule,MatFormFieldModule,MatIconModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  @Output() inputdata=new EventEmitter<string>();


  constructor(){
  }

  getName(e:Event){
     const input = e.target as HTMLInputElement;
     this.inputdata.emit(input.value);
  }
}
