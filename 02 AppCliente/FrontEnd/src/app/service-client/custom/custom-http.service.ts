import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { Router } from '@angular/router';


@Injectable({
    providedIn: 'root'
})
export class CustomHttpService {

    constructor(private http: HttpClient
    ) {
    }

    get(url: string): Observable<any> {
        return this.http.get<any>(url, { headers: this.getHeaders() })
            .pipe(
            retry(3),
            //catchError(this.handleError.bind(this)),
        );
    }

    downloadFile(url: string): Observable<Blob> {
        return this.http.get<Blob>(url, { responseType: 'blob' as 'json' });
    }

  getValue(url: string) {

        return this.http.get<any>(url, { headers: this.getHeaders() })
            .pipe(
            retry(3)
              //  catchError(this.handleError.bind(this))
        );
    }

    getValueString(url: string): Observable<any> {
        return this.http.get<any>(url, { headers: this.getHeadersString() })
            .pipe(
            retry(3),
              //  catchError(this.handleError.bind(this))
        );
    }

    put(url: string, body: any): Observable<any> {
        return this.http.put<any>(url, body, { headers: this.getHeaders() })
            .pipe(
            retry(3),
           // catchError(this.handleError.bind(this)),

        );
    }

    delete(url: string): Observable<boolean> {
        return this.http.delete<any>(url, { headers: this.getHeaders() })
            .pipe(
            retry(3),
          //  catchError(this.handleError.bind(this)),
            map(() => {
                return true;
            })
        );
    }

    postMap(url: string, body: any): Observable<any> {
        return this.http.post<any>(url, body, { headers: this.postHeaders() })
            .pipe(
            retry(3),
         //   catchError(this.handleError.bind(this)),
        );
    }

    post(url: string, body: any): Observable<any> {
        return this.http.post<any>(url, body, { headers: this.postHeaders() })
            .pipe(
                //catchError(this.handleError.bind(this))
            );
    }

    postFile(url: string, body: any): Observable<any> {
        return this.http.post<any>(url, body, { headers: this.postHeadersFile() })
            .pipe(
                //catchError(this.handleError.bind(this))
            );
    }

    addNewPost(url: string, newPost: FormData): Observable<FormData> {
        return this.http.post<any>(url, { headers: this.getHeaders() })
            .pipe(
            retry(3),
           // catchError(this.handleError)

        );
    }

    public getHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json')
            .append('Authorization', 'Bearer ' + localStorage.getItem('token'));
        return header;
  }


  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  }

    private getHeadersString(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'text/plain; charset=utf-8')
            .append('Authorization', 'Bearer ' + localStorage.getItem('token'))
            .append('responseType' , 'text' as 'json');
        return header;
    }

    private postHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json')
        .append('Authorization', 'Bearer ' + localStorage.getItem('token'));
        return header;
    }

    private postHeadersFile(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.append('Accept', 'application/json');
        return header;
    }


}
