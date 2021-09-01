import { Component, Input, OnInit } from '@angular/core';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';
import { roomDetails, roomtypeDetails } from '../../models/details';

@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCardComponent implements OnInit {
  @Input() room!: roomDetails;
  @Input() roomType!: roomtypeDetails;
  constructor(private roomtypeService: RoomtypeService) { }

  ngOnInit(): void {
    this.roomtypeService.getTypeById(this.room.rtCode).subscribe(
      rt => {
        this.roomType = rt;
      }
    );
  }

}
