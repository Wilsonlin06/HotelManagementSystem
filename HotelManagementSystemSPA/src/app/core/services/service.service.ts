import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { serviceDetails } from 'src/app/shared/models/details';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http: HttpClient) { }

  getAllServices(): Observable<serviceDetails[]> {
    return this.http.get(`${environment.apiUrl}` + "Service/allservices")
      .pipe(map(
        resp => resp as serviceDetails[]
      ));
  }

  getServiceById(id: number): Observable<serviceDetails> {
    return this.http.get(`${environment.apiUrl}` + "Service/" + id.toString())
      .pipe(map(
        resp => resp as serviceDetails
      ));
  }
  
  addRoom(model: serviceDetails): Observable<serviceDetails> {
    return this.http.post(`${environment.apiUrl}` + "Service/addservice", model)
      .pipe(map(
        resp => resp as serviceDetails
      ));
  }

  updateRoom(model: serviceDetails): Observable<serviceDetails> {
    return this.http.put(`${environment.apiUrl}` + "Service​/updateservice", model)
      .pipe(map(
        resp => resp as serviceDetails
      ));
  }
}
