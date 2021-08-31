using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class EnvironmentVarDto : BaseEntityDto
    {
        public EnvironmentVarDto()
        {
        }

        #region FKs

        public int KubernetesId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }
        public string Value { get; set; }
        public EnvType Type { get; set; }

        #endregion

        #region Relationships


        #endregion

    }
}
