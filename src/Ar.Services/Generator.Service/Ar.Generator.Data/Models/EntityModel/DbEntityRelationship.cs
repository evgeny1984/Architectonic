using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.EntityModel
{
    [Table(nameof(DbEntityRelationship))]
    public class DbEntityRelationship : BaseEntity
    {

        #region Columns

        public bool IsRequired { get; set; }

        public RelationshipType Type { get; set; }

        #endregion

        #region Relationships

        public DbEntity To { get; set; }

        #endregion

    }
}
