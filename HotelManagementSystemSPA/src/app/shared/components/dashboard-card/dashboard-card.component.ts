import { Component, Input, OnInit } from '@angular/core';
import { customerDetails } from '../../models/details';

@Component({
  selector: 'app-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.css']
})
export class DashboardCardComponent implements OnInit {
  @Input() customer!:customerDetails;
  constructor() { }

  ngOnInit(): void {
  }

}
