import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Titulo } from 'src/app/interface/titulo';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TituloService {
  readonly urlTitulo = environment.urlAPi + 'Titulo';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<Titulo[]>(this.urlTitulo)
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }

  post(titulo: Titulo) {
    return this.http.post(this.urlTitulo, titulo);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('Ocorreu um erro:', error.error);
    } else {
      console.error(
        `Retornado código ${error.status}, body: `, error.error);
    }
    return throwError(
      'Ocorreu um erro; Tente novamente mais tarde.');
  }
}
