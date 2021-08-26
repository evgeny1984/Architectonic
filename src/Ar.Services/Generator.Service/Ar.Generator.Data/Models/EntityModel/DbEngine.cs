using Ar.Generator.Data.Models.Applications;
using Architect.Dto.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.EntityModel
{
    [Table(nameof(DbEngine))]
    public class DbEngine : BaseEntity
    {

        public DbEngine()
        {
            DbEntities = new List<DbEntity>();
            Microservices = new List<Microservice>();
        }

        #region Columns

        public DbType DbType { get; set; }

        #endregion

        #region Relationships

        public ICollection<DbEntity> DbEntities { get; set; }

        public ICollection<Microservice> Microservices { get; set; }

        #endregion

    }
}
