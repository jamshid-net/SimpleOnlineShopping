import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { UserLoginComponent } from './user-login/user-login.component';

const routes:Routes=[
  {
    component:CategoryComponent,
    path:"category"
  },
  {
    component:UserRegisterComponent,
    path:"register"
  },
  {
    component:UserLoginComponent,
    path:"login"
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
