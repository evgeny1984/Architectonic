using System;

namespace Sp.Dto.Dto.Camunda
{
    public class HistoryProcessInstance
    {
        //
        // Summary:
        //     Last state of the process instance.
       // public ProcessInstanceState State;
        //
        //
        // Summary:
        //     The time the instance took to finish (in milliseconds).
        public long DurationInMillis;
        //
        // Summary:
        //     The time the instance ended.
        public DateTime EndTime;
        //
        // Summary:
        //     The time the instance was started.
        public DateTime StartTime;
        //
        // Summary:
        //     The name of the process definition that this process instance belongs to.
        public string ProcessDefinitionName;
        //
        // Summary:
        //     The key of the process definition that this process instance belongs to.
        public string ProcessDefinitionKey;
        //
        // Summary:
        //     The id of the process definition that this process instance belongs to.
        public string ProcessDefinitionId;

    }
}
