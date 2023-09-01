import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { TokenResponse } from '../user-register/user-register.component';
import { ErrorResponseRoot } from '../error.response';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {
  clientError?:string;
  
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
      this.http.post<TokenResponse|ErrorResponseRoot>("api/User/Login",LoginUser).subscribe(response=>{
        if(response && 'accessToken' in response){
        localStorage.setItem("token",response.accessToken);
        this.loginForm.reset();
          
        }
        if(response && 'Error' in response){
          console.log(response.Error);
          this.clientError = response.Error;
          setTimeout(() => {
            this.clientError='';
          }, 4000);
          
        }
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

