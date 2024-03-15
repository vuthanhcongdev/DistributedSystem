import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServerErrorComponent } from './server-error.component';
import { ServerErrorRoutingModule } from './server-error-routing.module';



@NgModule({
  declarations: [
    ServerErrorComponent
  ],
  imports: [
    CommonModule,
    ServerErrorRoutingModule
  ]
})
export class ServerErrorModule { }
