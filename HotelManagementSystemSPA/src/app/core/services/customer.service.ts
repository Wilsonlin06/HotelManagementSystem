import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { customerDetails } from 'src/app/shared/models/details';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<customerDetails[]> {
    return this.http.get(`${environment.apiUrl}` + "Customer/allcustomers")
      .pipe(map(
        resp => resp as customerDetails[]
      ));
  }

  getCustomerById(id: number): Observable<customerDetails>{
    return this.http.get(`${environment.apiUrl}` + "Customer/" + id.toString())
    .pipe(map(
      resp => resp as customerDetails
    ));
  }
  addCustomer(model: customerDetails): Observable<customerDetails>
  {
    return this.http.post(`${environment.apiUrl}` + "Customer/addcustomer", model)
    .pipe(map(
      resp => resp as customerDetails
    ));    
  }

  updateCustomer(model: customerDetails): Observable<customerDetails>
  {
    return this.http.put(`${environment.apiUrl}` + "Customer​/updatecustomer", model)
    .pipe(map(
      resp => resp as customerDetails
    ));
  }
}
