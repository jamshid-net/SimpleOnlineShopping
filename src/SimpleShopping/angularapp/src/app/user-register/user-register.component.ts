import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup,FormControl,Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';


@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent {
  errormessage?:string;
  constructor(private http:HttpClient){}
  registerForm = new FormGroup({
    fullName:new FormControl('',[Validators.required]),
    phone:new FormControl('',[Validators.required,Validators.pattern("[0-9 ]{12}")]),
    password:new FormControl('',[Validators.required,Validators.minLength(6)]),
    email:new FormControl('',[Validators.email,Validators.required]),
    shortAddress:new FormControl(''),
    confirmPassword:new FormControl('',[Validators.required]),
  },{validators:passwordMatchValidator()});

  Register(){
    if(this.registerForm.valid){
      let newUser:RegisterUserCommand ={
        fullName:this.registerForm.value.fullName,
        phone:this.registerForm.value.phone,
        email:this.registerForm.value.email,
        password:this.registerForm.value.password,
        shortAddress:this.registerForm.value.shortAddress,
      }
      this.http.post<TokenResponse>("api/User/Register",newUser).subscribe(response=>{
        localStorage.setItem("token",response.accessToken);
        this.registerForm.reset();
      },error=>{
        this.errormessage = error;
        console.log(this.errormessage);
        
      });


    }

  }
  
  get fullNameValid(){
    return this.registerForm.get("fullName");
  }
  get phoneValid(){
    return this.registerForm.get("phone");
  }
  get passwordValid(){
    return this.registerForm.get("password");
  }
  get emailValid(){
    return this.registerForm.get("email");
  }
  get confirmPasswordValid(){
    return this.registerForm.get("confirmPassword");
  }
  get passwordMathValid(){
    return this.registerForm.hasError('passwordMismatch');
  }
}
export interface RegisterUserCommand {
    fullName: string | undefined | null;
    phone: string | undefined | null;
    password: string | undefined | null;
    email: string | undefined | null;
    shortAddress: string | undefined | null;
   
}
function passwordMatchValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (password && confirmPassword && password.value !== confirmPassword.value) {
      return { passwordMismatch: true };
    }

    return null;
  };
}
export interface TokenResponse {
  accessToken: string;
}