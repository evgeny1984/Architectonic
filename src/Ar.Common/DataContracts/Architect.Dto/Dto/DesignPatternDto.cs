using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DesignPatternDto : BaseEntityDto
    {
        #region FKs

        public int SolutionId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string Problem { get; set; }

        #endregion

    }
}
