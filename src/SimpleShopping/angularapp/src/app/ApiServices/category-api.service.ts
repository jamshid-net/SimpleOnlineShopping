import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, pipe, throwError } from 'rxjs';
import { Category } from '../Models/CategoryResponse';

@Injectable({
  providedIn: 'root'
})
export class CategoryApiService {
  constructor(private http:HttpClient){}
    public categories?:Category[];
    getAllCategory(): Observable<Category[]> {
        return this.http.get<Category[]>("api/Category/GetAllCategory");
    }

}
