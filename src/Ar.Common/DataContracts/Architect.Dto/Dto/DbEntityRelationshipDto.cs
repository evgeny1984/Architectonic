using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DbEntityRelationshipDto : BaseEntityDto
    {
        #region FKs

        public int ToEntityId { get; set; }

        #endregion

        #region Columns

        public bool IsRequired { get; set; }

        public RelationshipType Type { get; set; }

        #endregion

        #region Relationships

        #endregion

    }
}
