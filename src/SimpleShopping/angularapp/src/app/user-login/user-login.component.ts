import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { TokenResponse } from '../user-register/user-register.component';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {
  errormessage?:string;
  constructor(private http:HttpClient) {}
  loginForm = new FormGroup({
    password:new FormControl('',[Validators.required,Validators.minLength(6)]),
    email:new FormControl('',[Validators.email,Validators.required]),

  });

  login(){
    if(this.loginForm.valid){
      let LoginUser:UserLoginModel ={
       
        email:this.loginForm.value.email,
        password:this.loginForm.value.password,
        
      }
      this.http.post<TokenResponse>("api/User/Login",LoginUser).subscribe(response=>{
        localStorage.setItem("token",response.accessToken);
        this.loginForm.reset();
      },error=>{
        this.errormessage = error;
        console.log(this.errormessage);
        
      });


    }
  }

  get passwordValid(){
    return this.loginForm.get("password");
  }
  get emailValid(){
    return this.loginForm.get("email");
  }
}
interface UserLoginModel{
  email: string | undefined | null,
  password: string | undefined | null
}

