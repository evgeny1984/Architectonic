using Ar.Generator.Data.Models.EntityModel;
using Ar.Generator.Data.Models.SolutionAppConfig;
using Architect.Dto.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(Microservice))]
    public class Microservice : Application
    {
        public Microservice()
        {
            ApiEndpoints = new List<ApiEndpoint>();
        }

        #region FKs

        public int DbEngineId { get; set; }

        #endregion

        #region Columns

        public bool UseServiceLayer { get; set; }

        public ServiceDiscoveryType ServiceDiscoveryType { get; set; }

        #endregion

        #region Relationships

        public ICollection<ApiEndpoint> ApiEndpoints { get; set; }

        public DbEngine DatabaseEngine { get; set; }

        #endregion

    }
}
