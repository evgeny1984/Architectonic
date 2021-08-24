using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.SolutionAppConfig
{
    [Table(nameof(Folder))]
    public class Folder : BaseEntity
    {
        public Folder()
        {
            SubFolders = new List<Folder>();
        }

        #region Columns

        public string Name { get; set; }

        public int Level{ get; set; }

        #endregion

        #region Relationships

        public ICollection<Folder> SubFolders { get; set; }

        #endregion
    }
}
