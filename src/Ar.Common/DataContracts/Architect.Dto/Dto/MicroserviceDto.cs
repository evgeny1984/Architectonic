using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class MicroserviceDto : ApplicationDto
    {

        public MicroserviceDto()
        {
            ApiEndpoints = new List<ApiEndpointDto>();
        }

        #region FKs

        public int DbEngineId { get; set; }

        #endregion

        #region Columns

        public bool UseServiceLayer { get; set; }

        public ServiceDiscoveryType ServiceDiscoveryType { get; set; }

        #endregion

        #region Relationships

        public ICollection<ApiEndpointDto> ApiEndpoints { get; set; }

        #endregion

    }
}
