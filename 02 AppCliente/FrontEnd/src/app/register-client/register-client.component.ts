import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router, ActivatedRoute, Params } from '@angular/router';
import {ServiceClient} from '../service-client/serviceClient'

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css']
})
export class RegisterClientComponent implements OnInit {


    myForm: FormGroup  = this.fb.group({
      Nombres: ['', [Validators.required]],
      Apellidos: ['', [Validators.required]],
      Correo: ['', [Validators.required, , Validators.email]],
      FechaNacimientoString: ['', [Validators.required]],
      Direccion: ['']
    })

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private serviceClient: ServiceClient
    ) { }

  ngOnInit(): void {
    
  }


  public errorHandling = (control: string, error: string) => {
    return this.myForm.controls[control].hasError(error);
  }

  date(e:any) {
    var convertDate = new Date(e.target.value).toISOString().substring(0, 10);
   // this.myForm.get('FechaNacimiento').setValue(convertDate, {
   //   onlyself: true
   // }) 
  }

  submitForm() {
    console.log(this.myForm.valid)
    if(this.myForm.valid){
 
    this.serviceClient.postSaveClient(this.myForm.value).subscribe(
      (result: any) =>{
        console.log(result);
        if(result.Correo == "-1"){
          alert("Ya existe clientes con el mismo correo.")
        }
        else{
          this.router.navigate(['/ListClient']);
        }
       
      }
    );
    }
  }
 

}
