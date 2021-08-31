using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DbEntityDto : BaseEntityDto
    {
        public DbEntityDto()
        {
            DbEntityFields = new List<DbEntityFieldDto>();
            DbEntityRelationships = new List<DbEntityRelationshipDto>();
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

        public ICollection<DbEntityRelationshipDto> DbEntityRelationships { get; set; }

        public ICollection<DbEntityFieldDto> DbEntityFields { get; set; }

        #endregion

    }
}
