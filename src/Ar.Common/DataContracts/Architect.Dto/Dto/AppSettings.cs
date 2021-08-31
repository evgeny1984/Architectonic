using Architect.Dto.EventBus;

namespace Architect.Dto.Dto
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public EventBusSettings EventBusSettings { get; set; }
        
    }

    public class ConnectionStrings
    {
        public string DataAccessPostgreProvider { get; set; }
        public string DataAccessSQliteProvider { get; set; }
    }
}
