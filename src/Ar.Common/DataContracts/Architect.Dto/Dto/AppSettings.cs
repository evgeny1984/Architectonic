namespace Architect.Dto.Dto
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DataAccessPostgreProvider { get; set; }
        public string DataAccessSQliteProvider { get; set; }
    }
}
