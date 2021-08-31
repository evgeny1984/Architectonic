using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DbEntityFieldDto : BaseEntityDto
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

        #endregion

    }
}
