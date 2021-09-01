import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { roomtypeDetails } from 'src/app/shared/models/details';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomtypeService {

  constructor(private http: HttpClient) { }

  getAllTypes(): Observable<roomtypeDetails[]> {
    return this.http.get(`${environment.apiUrl}` + "RoomType/alltypes")
      .pipe(map(
        resp => resp as roomtypeDetails[]
      ));
  }

  getTypeById(id:number): Observable<roomtypeDetails>{
    return this.http.get(`${environment.apiUrl}` + `RoomType/${id}`)
    .pipe(map(
      resp => resp as roomtypeDetails
    ));
  }
  
  addRoom(model: roomtypeDetails): Observable<roomtypeDetails>
  {
    return this.http.post(`${environment.apiUrl}` + "Room/addroom", model)
    .pipe(map(
      resp => resp as roomtypeDetails
    ));    
  }

  updateRoom(model: roomtypeDetails): Observable<roomtypeDetails>
  {
    return this.http.put(`${environment.apiUrl}` + "Room/updateroom", model)
    .pipe(map(
      resp => resp as roomtypeDetails
    ));
  }
  
}
