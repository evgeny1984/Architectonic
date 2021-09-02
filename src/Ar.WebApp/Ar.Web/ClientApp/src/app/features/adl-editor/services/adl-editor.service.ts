import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { AdlFile } from '@models/adl-file.model';
import { ServiceBase } from '@services/base.service';

@Injectable()
export class AdlEditorService extends ServiceBase {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  uploadAdlContent(adlFile: AdlFile) {
    return this.post('api/recognition', adlFile);
  }

}
