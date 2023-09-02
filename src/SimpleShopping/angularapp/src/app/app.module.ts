import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CategoryComponent } from './category/category.component';
import { AppRoutingModule } from './app-routing.module';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { MainComponent } from './admin/main/main.component';
import { ProductsComponent } from './products/products.component';
import { UsersComponent } from './users/users.component';
import { OrdersComponent } from './orders/orders.component';
import { FooterComponent } from './footer/footer.component';
import { DeleteDialogComponent } from './products/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from './products/edit-dialog/edit-dialog.component';
import { CreateDialogComponent } from './products/create-dialog/create-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    UserLoginComponent,
    UserRegisterComponent,
    NavbarComponent,
    HomeComponent,
    AdminComponent,
    MainComponent,
    ProductsComponent,
    UsersComponent,
    OrdersComponent,
    FooterComponent,
    DeleteDialogComponent,
    EditDialogComponent,
    CreateDialogComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule,FormsModule,ReactiveFormsModule, BrowserAnimationsModule,MatButtonModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
