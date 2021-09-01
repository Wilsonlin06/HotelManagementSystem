import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';
import { roomtypeDetails } from 'src/app/shared/models/details';

@Component({
  selector: 'app-roomtype',
  templateUrl: './roomtype.component.html',
  styleUrls: ['./roomtype.component.css']
})
export class RoomtypeComponent implements OnInit {
  id!:number;
  type!:roomtypeDetails;
  constructor(private currentRoute:ActivatedRoute,
    private roomtypeService: RoomtypeService) { }

  ngOnInit(): void {
    this.currentRoute.params.subscribe(
      c => {
        this.id = c['id'];
      }
    );
    this.roomtypeService.getTypeById(this.id).subscribe(
      t => {
        this.type = t;
      }
    );
  }

}
