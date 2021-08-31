using System.Collections.Generic;

namespace Architect.Dto.Dto
{
    public class ApiEndpointDto : BaseEntityDto
    {
        #region FKs

        public int MicroserviceId { get; set; }

        #endregion

        #region Columns

        public bool AuthorizationRequired { get; set; }

        public string Path { get; set; }

        public RequestType RequestType { get; set; }

        public EndpointType EndpointType { get; set; }

        #endregion

        #region Relationships

        public MicroserviceDto Microservice { get; set; }

        #endregion

    }
}
