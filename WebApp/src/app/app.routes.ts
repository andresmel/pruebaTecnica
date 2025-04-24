import { Routes } from '@angular/router';
import { LayoutPrivateComponent } from './features/Layouts/layout-private/layout-private.component';
import { CostumersComponent } from './features/pages/costumers/costumers.component';
import { NotFoundComponent } from './features/pages/not-found/not-found.component';


export const routes: Routes = [
  {
    path:"",
    component:LayoutPrivateComponent,
    children:[
      {path:"costumers",component:CostumersComponent},
      {path:"",redirectTo:"/costumers",pathMatch:"full"}
    ]
  },
  {path:"*",component:NotFoundComponent}

];
