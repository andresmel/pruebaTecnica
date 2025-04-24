import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/header/header.component';
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-layout-private',
  standalone: true,
  imports: [HeaderComponent,RouterOutlet],
  templateUrl: './layout-private.component.html',
  styleUrl: './layout-private.component.css'
})
export class LayoutPrivateComponent {

}
