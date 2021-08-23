export enum ProcessInstanceState {
  //
  // Summary:
  //     Running process instance
  Active = 0,
  //
  // Summary:
  //     Suspended process instances
  Suspended = 1,
  //
  // Summary:
  //     Suspended process instances
  Completed = 2,
  //
  // Summary:
  //     Suspended process instances
  ExternallyTerminated = 3,
  //
  // Summary:
  //     Terminated internally, for instance by terminating boundary event
  InternallyTerminated = 4

}
