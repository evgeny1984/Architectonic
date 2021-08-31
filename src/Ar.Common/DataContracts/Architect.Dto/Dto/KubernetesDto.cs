using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class KubernetesDto : BaseEntityDto
    {
        public KubernetesDto()
        {
            EnvVars = new List<EnvironmentVarDto>();
        }

        #region Columns

        public string YamlConfig { get; set; }

        public string Namespace { get; set; }

        public string IngressDomain { get; set; }

        public int ReplicasAmount { get; set; }

        public WorkloadType WorkloadType { get; set; }

        #endregion

        #region Relationships

        public PersistentVolumeClaimDto PVC { get; set; }

        public ICollection<EnvironmentVarDto> EnvVars { get; set; }

        #endregion

    }
}
