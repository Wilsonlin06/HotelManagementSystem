import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';  // import this

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { RoomComponent } from './rooms/room/room.component';
import { RoomtypeComponent } from './rooms/roomtype/roomtype.component';
import { ServiceComponent } from './rooms/service/service.component';
import { CustomerComponent } from './rooms/customer/customer.component';
import { DashboardCardComponent } from './shared/components/dashboard-card/dashboard-card.component';
import { CustomerCardComponent } from './shared/components/customer-card/customer-card.component';
import { RoomCardComponent } from './shared/components/room-card/room-card.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    RoomComponent,
    RoomtypeComponent,
    ServiceComponent,
    CustomerComponent,
    DashboardCardComponent,
    CustomerCardComponent,
    RoomCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
