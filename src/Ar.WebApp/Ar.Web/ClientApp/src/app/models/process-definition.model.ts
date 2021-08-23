export class ProcessDefinition {
  public id: string;
  public key: string;
  public category: string;
  public description: string;
  public name: string;
  public version: number;
  public resource: string;
  public deploymentId: string;
  public diagram: string;
  public suspended: Boolean;
  public tenantId: String;
  public versionTag: String;
  public historyTimeToLive: number;
  public startableInTasklist: Boolean;

  constructor() { }

}
