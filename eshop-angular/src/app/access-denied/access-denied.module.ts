import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccessDeniedComponent } from './access-denied.component';
import { AccessDeniedRoutingModule } from './access-denied-routing.module';



@NgModule({
  declarations: [
    AccessDeniedComponent
  ],
  imports: [
    CommonModule,
    AccessDeniedRoutingModule
  ]
})
export class AccessDeniedModule { }
