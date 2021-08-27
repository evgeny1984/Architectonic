using Architect.Dto.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.EntityModel
{
    [Table(nameof(DbEntityRelationship))]
    public class DbEntityRelationship : BaseEntity
    {
        #region FKs

        public int ToEntityId { get; set; }

        #endregion

        #region Columns

        public bool IsRequired { get; set; }

        public RelationshipType Type { get; set; }

        #endregion

        #region Relationships

        public DbEntity ToEntity { get; set; }

        #endregion

    }
}
