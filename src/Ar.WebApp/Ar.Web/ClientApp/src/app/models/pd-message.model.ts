import { VariableData } from "./variable-data.model";

export class ProcessDefinitionMessage {
  public messageName: string;
  public businessKey: string;
  public tenantId: string;
  public withoutTenantId: Boolean;
  public processInstanceId: string;
  public resultEnabled: Boolean;
  public data: VariableData;

  constructor() { }

}
