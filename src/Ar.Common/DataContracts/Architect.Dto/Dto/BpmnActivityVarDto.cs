using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class BpmnActivityVarDto : BaseEntityDto
    {
        #region FKs

        public int BpmnActivityId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string ValueType { get; set; }

        #endregion

        #region Relationships
        

        #endregion

    }
}
