import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { UsersModule } from '../users/users.module';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    UsersModule
  ]
})
export class HomeModule { }
