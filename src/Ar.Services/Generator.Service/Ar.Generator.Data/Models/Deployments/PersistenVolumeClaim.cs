using Ar.Generator.Data.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(PersistenVolumeClaim))]
    public class PersistenVolumeClaim : BaseEntity
    {

        #region Columns

        public decimal RequiredStorage { get; set; }
        public string StorageClass { get; set; }

        #endregion

        #region Relationships

        public DbEngine Kubernetes { get; set; }

        #endregion

    }
}
