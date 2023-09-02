import { Component, OnInit } from '@angular/core';
import { HttpServiceService } from '../ApiServices/http-service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { ProductPaginated } from '../Models/ProductPaginated';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit{
  productsPaginated!:ProductPaginated;
  totalPagesArray!:number[];
  constructor(private apihttp:HttpServiceService,private dialog: MatDialog){}
  ngOnInit(): void {
    this.GetPaginatedProducts(1);
  }
  
  GetPaginatedProducts(page:number){
    this.apihttp.GetPaginated<ProductPaginated>(`api/Product/GetPaginated?page=${page}&limit=10`).subscribe(res=>{
      this.productsPaginated = res;
      this.totalPagesArray = Array.from({ length: this.productsPaginated.totalPages }, (_, i) => i + 1);
    },error=> console.error(error));
  }
  
    openDialog(): void {
      this.dialog.open(DeleteDialogComponent, {
        width: '250px',
       
        
      });
    }
   
}
