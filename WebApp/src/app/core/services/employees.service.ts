import { Injectable } from '@angular/core';
import apiRest from "../../../../public/api/apiRest.json";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private _http:HttpClient) { }

  getEmployees(){
    return this._http.get(apiRest.employees);
  }
}
