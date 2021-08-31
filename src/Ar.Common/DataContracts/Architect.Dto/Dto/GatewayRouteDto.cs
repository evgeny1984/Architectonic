using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class GatewayRouteDto : BaseEntityDto
    {

        public GatewayRouteDto()
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

        #endregion

    }
}
