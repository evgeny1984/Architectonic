using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(GatewayRoute))]
    public class GatewayRoute : BaseEntity
    {
        public GatewayRoute()
        {
            UpstreamHttpMethods = new List<RequestType>();
        }

        #region FKs

        public int ApiGatewayId { get; set; }

        #endregion

        #region Columns

        public string DownstreamPathTemplate { get; set; }

        public string DownstreamScheme { get; set; }

        public string UpstreamPathTemplate { get; set; }

        public string DownstreamHost { get; set; }

        public string DownstreamPort { get; set; }

        #endregion

        #region Relationships

        public ICollection<RequestType> UpstreamHttpMethods { get; set; }

        public ApiGateway Gateway { get; set; }

        #endregion

    }
}
