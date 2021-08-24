using System;
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
        }

        #region Columns

        public DbType DbType { get; set; }

        #endregion

        #region Relationships

        public ICollection<DbEntity> DbEntities { get; set; }

        #endregion

    }
}
