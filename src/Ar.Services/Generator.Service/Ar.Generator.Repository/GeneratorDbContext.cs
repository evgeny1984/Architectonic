using Ar.Generator.Data.Mappings;
using Ar.Generator.Data.Models.Applications;
using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Ar.Generator.Data.Models.Deployments;
using Ar.Generator.Data.Models.EntityModel;
using Ar.Generator.Data.Models.SolutionAppConfig;
using Microsoft.EntityFrameworkCore;

namespace Ar.Generator.Repository
{
    public class GeneratorDbContext : DbContext
    {

        /// <summary>
        /// Default constructor is used by creating migration
        /// </summary>
        public GeneratorDbContext()
        {

        }

        public GeneratorDbContext(DbContextOptions<GeneratorDbContext> options) : base(options)
        {

        }

        #region DBSets

        public virtual DbSet<ApiEndpoint> ApiEndpoints { get; set; }
        public virtual DbSet<ApiGateway> ApiGateways { get; set; }
        public virtual DbSet<ClientApplication> ClientApplications { get; set; }
        public virtual DbSet<EventBus> EventBuses { get; set; }
        public virtual DbSet<FaaS> FaaSs { get; set; }
        public virtual DbSet<GatewayRoute> GatewayRoutes { get; set; }
        public virtual DbSet<Microservice> Microservices { get; set; }
        public virtual DbSet<BpmnActivity> BpmnActivities { get; set; }
        public virtual DbSet<BpmnActivityHandler> BpmnActivityHandlers { get; set; }
        public virtual DbSet<BpmnActivityVar> BpmnActivityVars { get; set; }
        public virtual DbSet<DesignPattern> DesignPatterns { get; set; }
        public virtual DbSet<ProcessInstance> ProcessInstances { get; set; }
        public virtual DbSet<SagaPattern> SagaPatterns { get; set; }
        public virtual DbSet<WorkflowEngine> WorkflowEngines { get; set; }
        public virtual DbSet<Deployment> Deployments { get; set; }
        public virtual DbSet<DockerCompose> DockerComposes { get; set; }
        public virtual DbSet<DockerComposeService> DockerComposeServices { get; set; }
        public virtual DbSet<EnvironmentVar> EnvironmentVars { get; set; }
        public virtual DbSet<Kubernetes> Kuberneteses { get; set; }
        public virtual DbSet<PersistentVolumeClaim> PersistentVolumeClaims { get; set; }
        public virtual DbSet<DbEngine> DbEngines { get; set; }
        public virtual DbSet<DbEntity> DbEntities { get; set; }
        public virtual DbSet<DbEntityField> DbEntityFields { get; set; }
        public virtual DbSet<DbEntityRelationship> DbEntityRelationships { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Solution> Solutions { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // =============Create all mappings=============
            new ApiGatewayMap(modelBuilder.Entity<ApiGateway>());
            new AppConfigMap(modelBuilder.Entity<AppConfig>());
            new ApplicationMap(modelBuilder.Entity<Application>());
            new BpmnActivityMap(modelBuilder.Entity<BpmnActivity>());
            new DbEngineMap(modelBuilder.Entity<DbEngine>());
            new DbEntityMap(modelBuilder.Entity<DbEntity>());
            new DockerComposeMap(modelBuilder.Entity<DockerCompose>());
            new DockerComposeServiceMap(modelBuilder.Entity<DockerComposeService>());
            new FolderMap(modelBuilder.Entity<Folder>());
            new KubernetesMap(modelBuilder.Entity<Kubernetes>());
            new MicroserviceMap(modelBuilder.Entity<Microservice>());
            new ProcessInstanceMap(modelBuilder.Entity<ProcessInstance>());
            new SolutionMap(modelBuilder.Entity<Solution>());
            new WorkflowEngineMap(modelBuilder.Entity<WorkflowEngine>());
            new GatewayRouteMap(modelBuilder.Entity<GatewayRoute>());
        }
    }
}
