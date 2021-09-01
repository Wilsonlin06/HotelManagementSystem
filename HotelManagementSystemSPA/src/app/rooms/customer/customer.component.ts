import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/core/services/customer.service';
import { RoomService } from 'src/app/core/services/room.service';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';
import { ServiceService } from 'src/app/core/services/service.service';
import { customerDetails, roomDetails, roomtypeDetails, serviceDetails } from 'src/app/shared/models/details';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  single!:boolean;
  customer!:customerDetails;
  customers!:customerDetails[];
  id!:number;
  allcustomers!:string;
  room!:roomDetails;
  rooms!:roomDetails[];
  roomType!:roomtypeDetails;
  roomTypes!:roomtypeDetails[];
  services!:serviceDetails[];
  enableEdit = false;
  enableEditIndex = null;
  constructor(private customerService: CustomerService, private currentRoute: ActivatedRoute,
     private roomTypeService: RoomtypeService, private roomService: RoomService, private serviceService: ServiceService) { }

  async ngOnInit(): Promise<void> {
    this.currentRoute.params.subscribe(
      c => {
        if(c['id'] == "allcustomers") this.allcustomers = c['id'];
        else this.id = c['id'];
      }
    );
    if(this.allcustomers != null)
    {
      this.single = false;
      this.customerService.getAllCustomers().subscribe(
        c => {
          this.customers = c;
        }
      );
      this.roomService.getAllRooms().subscribe(
        r => {
          this.rooms = r;
        }
      );
      this.roomTypeService.getAllTypes().subscribe(
        rt => {
          this.roomTypes = rt;
        }
      );
    }
    else
    {
      this.single = true;
      this.customerService.getCustomerById(this.id).subscribe(
        c => {
          this.customer = c;
          console.table(this.customer);
          this.roomService.getRoomById(this.customer.roomNo).subscribe(
            r => {
              this.room = r;            
              this.roomTypeService.getTypeById(this.room.rtCode).subscribe(
                rt => {
                  this.roomType = rt;
                }
              );
            }
          );
        }
      );
    }
    
    this.serviceService.getAllServices().subscribe(
      s => {
        this.services = s;
      }
    );
  }

  enableEditMethod(e: any, i: null) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }
}
