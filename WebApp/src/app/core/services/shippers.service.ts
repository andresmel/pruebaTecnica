import { Injectable } from '@angular/core';
import apiRest from "../../../../public/api/apiRest.json";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  constructor(private _http:HttpClient) { }

  getShippers(){
    return this._http.get(apiRest.shippers);
  }
}
