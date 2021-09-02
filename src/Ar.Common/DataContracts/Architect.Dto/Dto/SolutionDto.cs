using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class SolutionDto : BaseEntityDto
    {

        public SolutionDto()
        {
            Applications = new List<ApplicationDto>();
            Patterns = new List<DesignPatternDto>();
            SolutionStructure = new List<FolderDto>();
        }

        #region Columns

        public string Name { get; set; }
        public string Description { get; set; }
        public string AdlContent { get; set; }
        public string RepositoryName { get; set; }

        #endregion

        #region Relationships

        public ICollection<ApplicationDto> Applications { get; set; }

        public ICollection<DesignPatternDto> Patterns { get; set; }

        public ICollection<FolderDto> SolutionStructure { get; set; }

        #endregion

    }
}
