import { Injectable } from '@angular/core';
import apiRest from "../../../../public/api/apiRest.json";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private _http:HttpClient) { }

  postOrder(order:any){
    return this._http.post(apiRest.orders,order);
  }
}
