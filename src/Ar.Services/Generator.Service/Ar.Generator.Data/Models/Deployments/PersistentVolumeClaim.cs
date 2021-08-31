using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(PersistentVolumeClaim))]
    public class PersistentVolumeClaim : BaseEntity
    {

        #region FKs

        public int KubernetesId { get; set; }

        #endregion

        #region Columns

        public decimal RequiredStorage { get; set; }
        public string StorageClass { get; set; }

        #endregion

        #region Relationships

        public Kubernetes Kubernetes { get; set; }

        #endregion

    }
}
