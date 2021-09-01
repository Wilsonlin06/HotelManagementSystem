import { Component, Input, OnInit } from '@angular/core';
import { customerDetails, roomDetails, roomtypeDetails, serviceDetails } from '../../models/details';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.css']
})
export class CustomerCardComponent implements OnInit {
  @Input() customer!:customerDetails;
  @Input() roomType!:roomtypeDetails;
  @Input() services!:serviceDetails[];
  ttlBill!:number;
  constructor() { }

  ngOnInit(): void {
    this.ttlBill = this.roomType.rent - this.customer.advance;
  }
  addtBill(amount:number){
    this.ttlBill += amount;
  }
}
