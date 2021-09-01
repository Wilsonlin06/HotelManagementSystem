import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CustomerComponent } from './rooms/customer/customer.component';
import { RoomComponent } from './rooms/room/room.component';
import { RoomtypeComponent } from './rooms/roomtype/roomtype.component';
import { ServiceComponent } from './rooms/service/service.component';

const routes: Routes = [
  {path:"", component: HomeComponent},
  {path:"rooms/room/:id", component:RoomComponent},
  {path:"rooms/roomtype/:id", component:RoomtypeComponent},
  {path:"rooms/service",component:ServiceComponent},
  {path:"rooms/customer/:id",component:CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
