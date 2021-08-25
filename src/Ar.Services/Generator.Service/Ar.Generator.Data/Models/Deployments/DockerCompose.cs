using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Deployments
{
    [Table(nameof(DockerCompose))]
    public class DockerCompose : Deployment
    {

        public DockerCompose()
        {
            DockerComposeServices = new List<DockerComposeService>();
        }

        #region Columns

        public bool IncludeDockerFile { get; set; }

        #endregion

        #region Relationships

        public ICollection<DockerComposeService> DockerComposeServices { get; set; }

        #endregion

    }
}
