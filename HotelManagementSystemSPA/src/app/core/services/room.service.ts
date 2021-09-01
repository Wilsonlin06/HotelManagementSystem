import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { roomDetails } from 'src/app/shared/models/details';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RoomService {
  constructor(private http: HttpClient) { }

  getAllRooms() : Observable<roomDetails[]>
  {
    return this.http.get(`${environment.apiUrl}` + "Room/allrooms")
    .pipe(map(
      resp => resp as roomDetails[]
    ));
  }

  getRoomById(id:number): Observable<roomDetails>
  {
    var rooms = this.http.get(`${environment.apiUrl}` + "Room/" + id.toString())
    .pipe(map(
      resp => resp as roomDetails
    ));
    console.log(rooms);
    return rooms;
  }

  addRoom(model: roomDetails): Observable<roomDetails>
  {
    return this.http.post(`${environment.apiUrl}` + "Room/addroom", model)
    .pipe(map(
      resp => resp as roomDetails
    ));    
  }

  updateRoom(model: roomDetails): Observable<roomDetails>
  {
    return this.http.put(`${environment.apiUrl}` + "Room/updateroom", model)
    .pipe(map(
      resp => resp as roomDetails
    ));
  }

  // deleteRoom(model: roomDetails): Observable<roomDetails>
  // {    
  //   return this.http.delete(`${environment.apiUrl}` + "Room/deleteroom", model)
  //   .pipe(map(
  //     resp => resp as roomDetails
  //   ));
  // }
}
