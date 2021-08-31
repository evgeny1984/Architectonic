using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class ApiGatewayDto : BaseEntityDto
    {
        public ApiGatewayDto()
        {
            GatewayRoutes = new List<GatewayRouteDto>();
        }

        #region Relationships

        public ICollection<GatewayRouteDto> GatewayRoutes { get; set; }

        #endregion

    }
}
