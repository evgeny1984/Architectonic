import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { ProcessInstanceState } from '@models/process-instance-state.model';

@Pipe(
  {
    name: 'processState'
  })
export class ProcessInstanceStatePipe implements PipeTransform {

  transform(processState: ProcessInstanceState): string {
    let result: string = "";

    if (processState === undefined)
      return result;

    switch (processState) {
      case 0: {
        result = "Active";
        break;
      }
      case 1: {
        result = "Suspended";
        break;
      }
      case 2: {
        result = "Completed";
        break;
      }
      case 3: {
        result = "Externally Terminated";
        break;
      }
      case 4: {
        result = "Internally Terminated";
        break;
      }
    }

    return result;
  }

}
