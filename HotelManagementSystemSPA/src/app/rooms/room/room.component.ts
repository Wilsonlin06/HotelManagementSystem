import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { RoomService } from 'src/app/core/services/room.service';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';
import { ServiceService } from 'src/app/core/services/service.service';
import { roomDetails, roomtypeDetails, serviceDetails } from 'src/app/shared/models/details';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  id!:number;
  room!:roomDetails;
  rooms!:roomDetails[];
  type!:roomtypeDetails;
  services!:serviceDetails[];
  bill!:number;
  constructor(private roomService: RoomService, 
    private serviceService: ServiceService,
    private roomtypeService:RoomtypeService,
    private currentRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentRoute.params.subscribe(
      c => {
        this.id = c['id'];
        if(this.id != 0){          
          this.roomService.getRoomById(this.id).subscribe(
            r => {
              this.room = r;
              this.roomtypeService.getTypeById(r.rtCode).subscribe(
                rt => {
                  this.type = rt;
                  this.bill = rt.rent;
                }
              );
            }
          );
        }
        else{
          this.roomService.getAllRooms().subscribe(
            r => {
              this.rooms = r;
              console.log(r);
            }
          );
        }
      }
    );    
    this.serviceService.getAllServices().subscribe(
      s => {
        this.services = s;
      }
    );
  }
  addBill(amount:number){
    this.bill += amount;
  }
  getType(id:number){
    this.roomtypeService.getTypeById(id).subscribe(
      t =>{
        this.type = t;
      }
    );
  }
}
