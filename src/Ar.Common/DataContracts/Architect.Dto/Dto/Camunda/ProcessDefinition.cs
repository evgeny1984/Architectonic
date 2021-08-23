namespace Architect.Dto.Dto.Camunda
{
    public class ProcessDefinition
    {
        public string Id;
        public string Key;
        public string Category;
        public string Description;
        public string Name;
        public int Version;
        public string Resource;
        public string DeploymentId;
        public string Diagram;
        public bool Suspended;
        public string TenantId;
        public string VersionTag;
        public int HistoryTimeToLive;
        public bool StartableInTasklist;
    }
}
