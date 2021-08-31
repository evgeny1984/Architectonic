using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class DbEngineDto : BaseEntityDto
    {
        public DbEngineDto()
        {
            DbEntities = new List<DbEntityDto>();
            Microservices = new List<MicroserviceDto>();
        }

        #region Columns

        public DbType DbType { get; set; }

        #endregion

        #region Relationships

        public ICollection<DbEntityDto> DbEntities { get; set; }

        public ICollection<MicroserviceDto> Microservices { get; set; }

        #endregion

    }
}
