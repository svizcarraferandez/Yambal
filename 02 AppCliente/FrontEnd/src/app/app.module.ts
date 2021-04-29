import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import { RegisterClientComponent } from './register-client/register-client.component';
import { ListClientComponent } from './list-client/list-client.component';
/* import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table'; */
//import { MatTableModule } from '@angular/material/table'; 
//import { MatCard } from '@angular/material/card'; 
//import { MatFormFieldModule } from '@angular/material/form-field'; 
//import {FormControl, Validators} from '@angular/forms';
//import {MatFormFieldModule} from '@angular/material/form-field';

import {AngularMaterialModule} from './material.module'
import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RegisterClientComponent,
    ListClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    //MatTableModule,
   // MatFormFieldModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    //FormControl,
    //Validators,
   // MatCard,
/*     MatPaginator,
    MatTableDataSource */
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
