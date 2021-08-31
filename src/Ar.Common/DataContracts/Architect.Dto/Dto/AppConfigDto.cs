using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class AppConfigDto : BaseEntityDto
    {
        public AppConfigDto()
        {
            Applications = new List<ApplicationDto>();
        }

        #region Columns

        public string BaseName { get; set; }

        public int ServerPort { get; set; }

        public string AppNamespace { get; set; }

        public AppType ApplicationType { get; set; }

        #endregion

        #region Relationships

        public ICollection<ApplicationDto> Applications { get; set; }

        #endregion

    }
}
