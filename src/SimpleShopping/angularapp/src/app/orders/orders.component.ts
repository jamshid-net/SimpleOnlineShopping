import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../products/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {
  constructor(private dialog:MatDialog){}
  openDialog(): void {
    this.dialog.open(DeleteDialogComponent, {
      width: '250px',
     
      
    });
  }
}
