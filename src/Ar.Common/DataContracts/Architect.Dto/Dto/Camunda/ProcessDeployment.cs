namespace Architect.Dto.Dto.Camunda
{
    public class ProcessDeployment
    {
        public string Name { get; set; }
        public string Bpmn20Xml { get; set; }
        public bool DuplicateFiltering { get; set; }
    }
}
