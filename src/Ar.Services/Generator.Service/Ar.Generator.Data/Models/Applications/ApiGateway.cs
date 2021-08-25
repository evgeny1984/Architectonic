using Ar.Generator.Data.Models.SolutionAppConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(ApiGateway))]
    public class ApiGateway : Application
    {
        public ApiGateway()
        {
            GatewayRoutes = new List<GatewayRoute>();
        }

        #region Relationships

        public ICollection<GatewayRoute> GatewayRoutes { get; set; }

        #endregion

    }
}
