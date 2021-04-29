import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NavbarComponent} from '../app/navbar/navbar.component';
import {ListClientComponent} from '../app/list-client/list-client.component';
import {RegisterClientComponent} from '../app/register-client/register-client.component';

const routes: Routes = [

  { path: 'navbar', component: NavbarComponent },
  { path: 'ListClient', component: ListClientComponent },
  { path: 'RegisterClient', component: RegisterClientComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'ListClient' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
