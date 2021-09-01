import { Component, Input, OnInit } from '@angular/core';
import { roomDetails, roomtypeDetails } from '../../models/details';

@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCardComponent implements OnInit {
  @Input() room!: roomDetails;
  @Input() roomType!: roomtypeDetails;
  constructor() { }

  ngOnInit(): void {
  }

}
