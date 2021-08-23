import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ServiceBase } from '@services/base.service';
import { Observable } from 'rxjs/internal/Observable';
import { ProcessDefinition } from '@models/process-definition.model';
import { ProcessDefinitionMessage } from '@models/pd-message.model';
import { ProcessDefinitionBpmn } from '@models/pd-bpmn';
import { ProcessDefinitionDeployment } from '@models/pd-deployment';
import { HistoryProcessInstance } from '@models/history-process-instance.model';

@Injectable()
export class CamundaService extends ServiceBase {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  getAllProcessDefinitions(): Observable<Array<ProcessDefinition>> {
    return this.fetchData<Array<ProcessDefinition>>('api/processdefinition');
  }

  getProcessInstancesHistory(): Observable<Array<HistoryProcessInstance>> {
    return this.fetchData<Array<HistoryProcessInstance>>('api/history');
  }

  getProcessDefinitionById(id: string): Observable<ProcessDefinition> {
    return this.fetchData<ProcessDefinition>(`api/processdefinition/${id}`);
  }

  getProcessDefinitionDiagram(id: string): Observable<ProcessDefinitionBpmn> {
    return this.fetchData<ProcessDefinitionBpmn>(`api/processdefinition/${id}/xml`);
  }

  createProcessDefinition(deployment: ProcessDefinitionDeployment) {
    return this.post('api/processdefinition', deployment);
  }

  updateProcessDefinition(processDefinition: ProcessDefinition) {
    return this.put('api/processdefinition', processDefinition);
  }

  deleteProcessDefinition(processDefinitionId: string): Observable<string> {
    return this.delete(`api/processdefinition/${processDefinitionId}`);
  }

  sendCorrelationMessage(message: ProcessDefinitionMessage) {
    return this.post(`api/message`, message);
  }

  throwSignal(signalName: string) {
    return this.fetchData(`api/message/${signalName}`);
  }

}
