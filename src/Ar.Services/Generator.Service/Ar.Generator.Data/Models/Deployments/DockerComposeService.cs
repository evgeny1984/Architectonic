using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(DockerComposeService))]
    public class DockerComposeService : BaseEntity
    {

        public DockerComposeService()
        {
            EnvVars = new List<EnvironmentVar>();
        }

        #region FKs

        public int DockerComposeId { get; set; }

        #endregion

        #region Columns

        public string Name { get; set; }

        public string Ports { get; set; }

        #endregion

        #region Relationships

        public ICollection<EnvironmentVar> EnvVars { get; set; }

        public DockerCompose DockerCompose { get; set; }

        #endregion

    }
}
