using Architect.Dto.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.EntityModel
{
    [Table(nameof(DbEntity))]
    public class DbEntity : BaseEntity
    {
        public DbEntity()
        {
            DbEntityFields = new List<DbEntityField>();
            DbEntityRelationships = new List<DbEntityRelationship>();
        }

        #region FKs

        public int DbEngineId { get; set; }

        #endregion

        #region Columns

        public bool AutoIncrement { get; set; }

        public string Name { get; set; }

        public bool CreateDto { get; set; }

        public DbEntityType EntityType { get; set; }

        #endregion

        #region Relationships

        public ICollection<DbEntityRelationship> DbEntityRelationships { get; set; }

        public ICollection<DbEntityField> DbEntityFields { get; set; }

        public DbEngine DbEngine { get; set; }

        #endregion

    }
}
