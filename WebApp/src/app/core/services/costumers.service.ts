import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import apiRest from "../../../../public/api/apiRest.json";

@Injectable({
  providedIn: 'root'
})
export class CostumersService {

  constructor(private _http:HttpClient) { }

  getCostumers(){
    return this._http.get(apiRest.costumers.apiPrediction);
  }

  getOrderByCostumer(costumer:any){
    return this._http.post(apiRest.costumers.apiOrderByCostumer,costumer);
  }

  getFilterbyCustomerName(costumer:any){
    return this._http.post(apiRest.costumers.apiFilterByCostumer,costumer);
  }
}
