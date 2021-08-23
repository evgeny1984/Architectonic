namespace Architect.Dto.Dto.Camunda
{
    public class CamundaMessage
    {
        public string MessageName;
        public string BusinessKey;
        public string TenantId;
        public string ProcessInstanceId;
        public bool WithoutTenantId;
        public bool ResultEnabled;
        public VariableData Data;
    }
}
