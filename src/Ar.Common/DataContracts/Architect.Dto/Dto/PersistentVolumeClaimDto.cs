using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class PersistentVolumeClaimDto : BaseEntityDto
    {
        #region FKs

        public int KubernetesId { get; set; }

        #endregion

        #region Columns

        public decimal RequiredStorage { get; set; }
        public string StorageClass { get; set; }

        #endregion

        #region Relationships


        #endregion

    }
}
