import { Component, OnInit } from '@angular/core';
import { CategoryApiService } from '../ApiServices/category-api.service';
import { Category } from '../Models/CategoryResponse';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  constructor(private categoryService:CategoryApiService){}
  public categories?:Category[];
 
  ngOnInit(): void {
    console.log("hello");
    
    this.categoryService.getAllCategory().subscribe(res=>{
        this.categories = res;
    },error=> console.error(error));
  }


}
