using Architect.Dto.EventBus;

namespace Architect.Dto.Dto
{
    public class AppSettings
    {
        public string ServiceGatewayUrl { get; set; }

        /// <summary>
        /// External url to camunda engine server used by Angular Client
        /// </summary>
        public string CamundaEngineUrl { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
        public EventBusSettings EventBusSettings { get; set; }
        
    }

    public class ConnectionStrings
    {
        public string DataAccessPostgreProvider { get; set; }
        public string DataAccessSQliteProvider { get; set; }
    }
}
