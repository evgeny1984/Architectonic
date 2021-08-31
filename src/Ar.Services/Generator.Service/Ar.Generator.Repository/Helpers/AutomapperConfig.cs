using Ar.Generator.Data.Models.Applications;
using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Ar.Generator.Data.Models.Deployments;
using Ar.Generator.Data.Models.EntityModel;
using Ar.Generator.Data.Models.SolutionAppConfig;
using Architect.Dto.Dto;
using AutoMapper;

namespace Ar.Generator.Repository.Helpers
{
    public class AutomapperConfig
    {
        private static MapperConfiguration config;
        private static Mapper _mapper;

        /// <summary>
        /// Configures all entities mapping to bo
        /// </summary>
        public static void Configure()
        {

            config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ApiEndpoint, ApiEndpointDto>()
                    .ReverseMap();

                cfg.CreateMap<ApiGateway, ApiGatewayDto>()
                    .ReverseMap();

                cfg.CreateMap<AppConfig, AppConfigDto>()
                    .ReverseMap();

                cfg.CreateMap<Application, ApplicationDto>()
                    .Include<ClientApplication, ClientApplicationDto>()
                    .Include<FaaS, FaasDto>()
                    .Include<EventBus, EventBusDto>()
                    .Include<Microservice, MicroserviceDto>()
                    .ReverseMap();

                cfg.CreateMap<ClientApplication, ClientApplicationDto>()
                    .ReverseMap();

                cfg.CreateMap<FaaS, FaasDto>()
                    .ReverseMap();

                cfg.CreateMap<EventBus, EventBusDto>()
                    .ReverseMap();

                cfg.CreateMap<Microservice, MicroserviceDto>()
                    .ReverseMap();

                cfg.CreateMap<BpmnActivity, BpmnActivityDto>()
                    .ReverseMap();

                cfg.CreateMap<BpmnActivityHandler, BpmnActivityHandlerDto>()
                   .ReverseMap();

                cfg.CreateMap<BpmnActivityVar, BpmnActivityVarDto>()
                    .ReverseMap();

                cfg.CreateMap<DbEngine, DbEngineDto>()
                    .ReverseMap();

                cfg.CreateMap<DbEntity, DbEntityDto>()
                    .ReverseMap();

                cfg.CreateMap<DbEntityField, DbEntityFieldDto>()
                    .ReverseMap();

                cfg.CreateMap<DbEntityRelationship, DbEntityRelationshipDto>()
                    .ReverseMap();

                cfg.CreateMap<Deployment, DeploymentDto>()
                    .ReverseMap();

                cfg.CreateMap<DesignPattern, DesignPatternDto>()
                    .Include<SagaPattern, SagaPatternDto>()
                    .ReverseMap();

                cfg.CreateMap<SagaPattern, SagaPatternDto>()
                    .ReverseMap();

                cfg.CreateMap<DockerCompose, DockerComposeDto>()
                    .ReverseMap();

                cfg.CreateMap<DockerComposeService, DockerComposeServiceDto>()
                    .ReverseMap();

                cfg.CreateMap<EnvironmentVar, EnvironmentVarDto>()
                    .ReverseMap();

                cfg.CreateMap<Folder, FolderDto>()
                    .ReverseMap();

                cfg.CreateMap<GatewayRoute, GatewayRouteDto>()
                    .ReverseMap();

                cfg.CreateMap<Kubernetes, KubernetesDto>()
                    .ReverseMap();

                cfg.CreateMap<PersistentVolumeClaim, PersistentVolumeClaimDto>()
                    .ReverseMap();

                cfg.CreateMap<ProcessInstance, ProcessInstanceDto>()
                    .ReverseMap();

                cfg.CreateMap<Solution, SolutionDto>()
                    .ReverseMap();

                cfg.CreateMap<WorkflowEngine, WorkflowEngineDto>()
                    .ReverseMap();

            });

        }

        public static MapperConfiguration Config
        {
            get
            {
                return config;
            }
        }

        public static IMapper Mapper => _mapper ?? (_mapper = new Mapper(config));
    }
}
