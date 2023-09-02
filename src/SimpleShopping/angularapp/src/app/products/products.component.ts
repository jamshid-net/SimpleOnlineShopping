import { Component } from '@angular/core';
import { HttpServiceService } from '../ApiServices/http-service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  constructor(private apihttp:HttpServiceService,private dialog: MatDialog){}

  GetPaginatedProducts(){

  }
  
    openDialog(): void {
      this.dialog.open(DeleteDialogComponent, {
        width: '250px',
       
        
      });
    }
   
}
