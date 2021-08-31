import { BaseEntity } from "./base-entity.model";

export class Solution extends BaseEntity{
  public name: string;
  public description: string;
  public repositoryName: string; 
  public adlContent: string; 

  //TODO Add required models
  //public applications: Array<Application>;
  //public patterns: Array<DesignPattern>;
  //public solutionStructure: Array<Folder>;


}
