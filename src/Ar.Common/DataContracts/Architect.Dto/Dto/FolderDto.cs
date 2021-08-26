using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class FolderDto : BaseEntityDto
    {
        public FolderDto()
        {
            SubFolders = new List<FolderDto>();
        }

        #region FKs

        public int ParentFolderId { get; set; }

        public int SolutionId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public int Level { get; set; }

        #endregion

        #region Relationships

        public ICollection<FolderDto> SubFolders { get; set; }

        #endregion

    }
}
