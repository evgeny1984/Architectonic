using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.EntityModel
{
    [Table(nameof(DbEntityField))]
    public class DbEntityField : BaseEntity
    {
        #region FKs

        public int DbEntityId { get; set; }

        #endregion

        #region Columns

        public bool IsRequired { get; set; }

        public string Name { get; set; }

        public int MaxLength { get; set; }

        public DataType DataType { get; set; }

        #endregion

        #region Relationships

        public DbEntity DbEntity { get; set; }

        #endregion

    }
}
