import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  userIsAuthorized():boolean{
    let token = localStorage.getItem("token");
    if(token?.startsWith("ey")){
      return true;
    }
    else return false;
  }

}
