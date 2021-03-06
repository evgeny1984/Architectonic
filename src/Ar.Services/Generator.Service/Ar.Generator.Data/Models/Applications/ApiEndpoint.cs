using Architect.Dto.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.Generator.Data.Models.Applications
{
    [Table(nameof(ApiEndpoint))]
    public class ApiEndpoint : BaseEntity
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

        public Microservice Microservice { get; set; }

        #endregion

    }
}
