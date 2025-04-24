import { Injectable } from '@angular/core';
import apiRest from "../../../../public/api/apiRest.json";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private _http:HttpClient) { }

  getProducts(){
    return this._http.get(apiRest.products);
  }
}
