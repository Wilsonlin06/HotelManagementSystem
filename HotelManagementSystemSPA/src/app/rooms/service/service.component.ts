import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/core/services/service.service';
import { serviceDetails } from 'src/app/shared/models/details';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {
  services!:serviceDetails[];
  constructor(private serviceService: ServiceService) { }

  ngOnInit(): void {
    this.serviceService.getAllServices().subscribe(
      s => {
        this.services = s;
      }
    );
  }

}
