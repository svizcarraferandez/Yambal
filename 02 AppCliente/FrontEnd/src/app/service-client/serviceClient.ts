import { Injectable, Injector } from '@angular/core';
import { environment } from '../../environments/environment';
import { clientModel } from '../model/clientModel';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CustomHttpService } from '../service-client/custom/custom-http.service';

@Injectable({
  providedIn: 'root'
})

export class ServiceClient {


    baseUrl: string = environment.baseUrlClientApi;
    getClientAll = 'Client/GetLista';
    postSave = 'Client/SaveClient';

    constructor(
        private customhttp: CustomHttpService
      ) {

        
       }

    listClientAll(params: any): Observable<clientModel[]> {
        let url: string = `${this.baseUrl}${this.getClientAll}`

        const result = this.customhttp.getValue(url)
          .pipe(
             map((data: clientModel[]) => {
            return this.procesarData(data);
          }) 
          
          );
        return result;
      }

      postSaveClient(lista: any) {
        const json = JSON.stringify(lista);
        return this.customhttp.post(this.baseUrl + this.postSave, json);
      }

      procesarData(data: any[]) {
        let dataSend: any[] = [];
        data.forEach((values: any, keys: number) => {
          let tempObj: any = {};
          Object.keys(values).forEach((value: any) => {
            tempObj[value.charAt(0).toUpperCase() + value.slice(1)] = values[value];
          });
          dataSend.push(tempObj);
        });
        return dataSend;
      }
    
}