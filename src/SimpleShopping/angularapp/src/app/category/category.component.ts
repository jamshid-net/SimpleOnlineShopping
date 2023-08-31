import { Component, OnInit } from '@angular/core';
import { Category } from '../Models/CategoryResponse';
import { HttpServiceService } from '../ApiServices/http-service.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  constructor(private categoryService:HttpServiceService){}
  public categories?:Category[];
  baseUrl:string = "api/Category/"
  ngOnInit(): void {
    this.categoryService.GetAll<Category>(this.baseUrl+"GetAll").subscribe(res=>{
        this.categories = res;
    },error=> console.error(error));
  }
  Delete(id:number){
      
  }
  


}
