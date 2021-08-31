import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ServiceBase } from '@services/base.service';
import { Solution } from '@models/solution.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class SolutionsOverviewService extends ServiceBase {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  getAllSolutions(): Observable<Array<Solution>> {
    return this.fetchData<Array<Solution>>('api/solutions');
  }


  getSolutionById(id: number): Observable<Solution> {
    return this.fetchData<Solution>(`api/solutions/${id}`);
  }

  deleteSolution(solutionId: number): Observable<string> {
    return this.delete(`api/solutions/${solutionId}`);
  }

}
