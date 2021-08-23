import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { retry, catchError, share } from 'rxjs/operators';

export class ServiceBase {

  constructor(private http: HttpClient, private baseUrl: string) {
  }

  fetchData<T>(relativeUrl: string): Observable<T> {
    const requestUrl = this.baseUrl + relativeUrl;
    console.log(`http.get(${requestUrl}`);
    return this.http.get<T>(requestUrl, { headers: this.headers() })
      .pipe(
        retry(3),
        catchError(this.errorHandler)
      );
  }

  post<T>(relativeUrl: string, data: any): Observable<T> {
    const requestUrl = this.baseUrl + relativeUrl;
    console.log(`http.post(${requestUrl}`);
    return this.http.post<T>(requestUrl, data, { headers: this.headers() })
      .pipe(
        retry(3),
        catchError(this.errorHandler)
      );
  }

  put<T>(relativeUrl: string, data: any): Observable<T> {
    const requestUrl = this.baseUrl + relativeUrl;
    console.log(`http.put(${requestUrl}`);
    return this.http.put<T>(requestUrl, data)
      .pipe(
        retry(3),
        catchError(this.errorHandler)
      );
  }

  delete(relativeUrl: string): Observable<string> {
    const requestUrl = this.baseUrl + relativeUrl;
    console.log(`http.delete(${requestUrl}`);
    return this.http.delete(requestUrl, { headers: this.headers() })
      .pipe(
        retry(3),
        catchError(this.errorHandler)
      );
  }

  private headers(): HttpHeaders {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    return headers;
  }

  private errorHandler(error: Error | any): Observable<any> {
    // Try to get inner exception prior to "Internal server errror"
    if (error.error && error.error.message) {
      error = error.error;
    }
    return observableThrowError(error);
  }

}
