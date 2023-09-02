import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn:"root"
})
export class HttpServiceService {

  constructor(private http:HttpClient) { }

  GetAll<T>(url:string):Observable<T[]>{
    return this.http.get<T[]>(url);
  }

 
  GetById<T>(url:string):Observable<T>{
    return this.http.get<T>(url);
  }

  Create<T>(model:any,url:string):Observable<T>{
    return this.http.post<T>(url,model);
  }

  Update<T>(model:any,url:string):Observable<T>{
    return this.http.put<T>(url,model);
  }

  Delete<T>(url:string):Observable<T>{
    return this.http.delete<T>(url);
  }

  GetPaginated<T>(url:string):Observable<T>{
    return this.http.get<T>(url);
  }


}
