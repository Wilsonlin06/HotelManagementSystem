import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  type!:roomtypeDetails;
  services!:serviceDetails[];
  constructor(private roomService: RoomService, 
    private serviceService: ServiceService,
    private roomtypeService:RoomtypeService,
    private currentRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentRoute.params.subscribe(
      c => {
        this.id = c['id'];
      }
    );
    this.roomService.getRoomById(this.id).subscribe(
      r => {
        this.room = r;
        this.roomtypeService.getTypeById(r.rtCode).subscribe(
          rt => {
            this.type = rt;
          }
        );
      }
    );
    this.serviceService.getAllServices().subscribe(
      s => {
        this.services = s;
      }
    );
  }
}
