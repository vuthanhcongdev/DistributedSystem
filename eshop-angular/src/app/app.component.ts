import { AfterViewChecked, Component, ElementRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements AfterViewChecked {

  constructor(private elementRef: ElementRef){

  }

  ngAfterViewChecked(): void {
    var s = document.createElement("script");
    s.type = "text/javascript";
    s.src = "../../assets/js/custom.js";
    this.elementRef.nativeElement.appendChild(s);
  }
  title = 'eshop-angular';
}
