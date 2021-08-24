using System;
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
        }

        #region Columns

        public bool AutoIncrement { get; set; }
        public string Name{ get; set; }
        public bool CreateDto{ get; set; }
        public DbEntityType EntityType { get; set; }

        #endregion

        #region Relationships

        public DbEntityRelationship DbEntityRelationship { get; set; }
        public ICollection<DbEntityField> DbEntityFields { get; set; }

        #endregion

    }
}
