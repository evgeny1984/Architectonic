import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { AppSettings } from "../app.settings";

@Injectable()
export class ConfigurationService {

  constructor(private http: HttpClient) { }

  loadConfig(): Observable<AppSettings> {
    const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
    let url = `${baseURI}api/config/appsettings`;
    return this.http.get(url).pipe(
      map((response) => {
        console.log('server settings loaded');
        return <AppSettings>response;
      }));
  }
}
