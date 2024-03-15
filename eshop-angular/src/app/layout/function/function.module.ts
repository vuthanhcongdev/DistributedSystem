import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FunctionComponent } from './function.component';
import { FunctionRoutingModule } from './function-routing.module';



@NgModule({
  declarations: [
    FunctionComponent
  ],
  imports: [
    CommonModule,
    FunctionRoutingModule
  ]
})
export class FunctionModule { }
