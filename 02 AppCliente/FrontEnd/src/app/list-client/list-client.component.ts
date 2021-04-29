import { Component, OnInit } from '@angular/core';
import {ServiceClient} from '../service-client/serviceClient'


@Component({
  selector: 'app-list-client',
  templateUrl: './list-client.component.html',
  styleUrls: ['./list-client.component.css']
})
export class ListClientComponent implements OnInit {
  
  displayedColumns: string[] = ['name', 'weight','symbol', 'FechaNacimientoString'];
  //dataSource = ELEMENT_DATA;
  dataSource = [];
  constructor(
    private serviceClient: ServiceClient
  ) { }

  ngOnInit(): void {

    this.listClientAll();
  }
 
  listClientAll(){

   this.serviceClient.listClientAll(null)
    .subscribe(
      (result: any) =>{

        console.log(result);

        this.dataSource = result;
      }
    );

  }  

} 
