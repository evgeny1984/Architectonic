import { ProcessInstanceState } from "./process-instance-state.model";

export class HistoryProcessInstance {
  public state: ProcessInstanceState;
  public durationInMillis: number;
  public endTime: Date | undefined;
  public startTime: Date | undefined;
  public processDefinitionName: string;
  public processDefinitionKey: string;
  public processDefinitionId: string;

  constructor() { }

}
