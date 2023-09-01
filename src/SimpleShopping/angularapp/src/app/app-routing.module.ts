import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { MainComponent } from './admin/main/main.component';
import { ProductsComponent } from './products/products.component';
import { UsersComponent } from './users/users.component';
import { OrdersComponent } from './orders/orders.component';

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
  {
    component:AdminComponent,
    path:"admin",
    children:[
      {
        component:MainComponent,
        path:""
      },
      {
        component:CategoryComponent,
        path:"categories"
      },
      {
        component:ProductsComponent,
        path:"products"
      },
      {
        component:UsersComponent,
        path:"users"
      },
      {
        component:OrdersComponent,
        path:"orders"
      },
      {
        component:UserLoginComponent,
        path:"login"
      },
      {
        component:UserRegisterComponent,
        path:"register"
      }
    
    ]
  },
  {
    component:HomeComponent,
    path:""
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
