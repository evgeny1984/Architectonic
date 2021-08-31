using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class SagaPatternDto : DesignPatternDto
    {
        #region Relationships

        public WorkflowEngineDto WorkflowEngine { get; set; }

        #endregion

    }
}
