using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ar.Generator.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseName = table.Column<string>(type: "text", nullable: true),
                    ServerPort = table.Column<int>(type: "integer", nullable: false),
                    AppNamespace = table.Column<string>(type: "text", nullable: true),
                    ApplicationType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbEngine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DbType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEngine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RepositoryName = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DbEngineId = table.Column<int>(type: "integer", nullable: false),
                    AutoIncrement = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreateDto = table.Column<bool>(type: "boolean", nullable: false),
                    EntityType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbEntity_DbEngine_DbEngineId",
                        column: x => x.DbEngineId,
                        principalTable: "DbEngine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigurationId = table.Column<int>(type: "integer", nullable: false),
                    SolutionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IncludeDockerFile = table.Column<bool>(type: "boolean", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_AppConfig_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "AppConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesignPattern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolutionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Problem = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignPattern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignPattern_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: false),
                    SolutionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folder_Folder_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folder_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbEntityField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DbEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    DataType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEntityField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbEntityField_DbEntity_DbEntityId",
                        column: x => x.DbEntityId,
                        principalTable: "DbEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbEntityRelationship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEntityRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbEntityRelationship_DbEntity_ToEntityId",
                        column: x => x.ToEntityId,
                        principalTable: "DbEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApiGateway",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiGateway", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiGateway_Application_Id",
                        column: x => x.Id,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BpmnActivityHandler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponsibleApplicationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TransactionEndpoint = table.Column<string>(type: "text", nullable: true),
                    CompensatingTransactionEndpoint = table.Column<string>(type: "text", nullable: true),
                    NotifyOnFailure = table.Column<bool>(type: "boolean", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BpmnActivityHandler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BpmnActivityHandler_Application_ResponsibleApplicationId",
                        column: x => x.ResponsibleApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Framework = table.Column<string>(type: "text", nullable: true),
                    ClientType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientApplication_Application_Id",
                        column: x => x.Id,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deployment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    DockerRegistry = table.Column<string>(type: "text", nullable: true),
                    DeploymentType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deployment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deployment_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventBus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventBus_Application_Id",
                        column: x => x.Id,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaaS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaaS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaaS_Application_Id",
                        column: x => x.Id,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Microservice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DbEngineId = table.Column<int>(type: "integer", nullable: false),
                    UseServiceLayer = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceDiscoveryType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microservice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Microservice_Application_Id",
                        column: x => x.Id,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Microservice_DbEngine_DbEngineId",
                        column: x => x.DbEngineId,
                        principalTable: "DbEngine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEngine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SagaPatternId = table.Column<int>(type: "integer", nullable: false),
                    RestApi = table.Column<string>(type: "text", nullable: true),
                    IsAuthorizationRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsWebModelerIncluded = table.Column<bool>(type: "boolean", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowEngine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowEngine_DesignPattern_SagaPatternId",
                        column: x => x.SagaPatternId,
                        principalTable: "DesignPattern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GatewayRoute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApiGatewayId = table.Column<int>(type: "integer", nullable: false),
                    DownstreamPathTemplate = table.Column<string>(type: "text", nullable: true),
                    DownstreamScheme = table.Column<string>(type: "text", nullable: true),
                    UpstreamPathTemplate = table.Column<string>(type: "text", nullable: true),
                    DownstreamHost = table.Column<string>(type: "text", nullable: true),
                    DownstreamPort = table.Column<string>(type: "text", nullable: true),
                    UpstreamHttpMethods = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatewayRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatewayRoute_ApiGateway_ApiGatewayId",
                        column: x => x.ApiGatewayId,
                        principalTable: "ApiGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DockerCompose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncludeDockerFile = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockerCompose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DockerCompose_Deployment_Id",
                        column: x => x.Id,
                        principalTable: "Deployment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kubernetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YamlConfig = table.Column<string>(type: "text", nullable: true),
                    Namespace = table.Column<string>(type: "text", nullable: true),
                    IngressDomain = table.Column<string>(type: "text", nullable: true),
                    ReplicasAmount = table.Column<int>(type: "integer", nullable: false),
                    WorkloadType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kubernetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kubernetes_Deployment_Id",
                        column: x => x.Id,
                        principalTable: "Deployment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiEndpoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MicroserviceId = table.Column<int>(type: "integer", nullable: false),
                    AuthorizationRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: true),
                    RequestType = table.Column<int>(type: "integer", nullable: false),
                    EndpointType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiEndpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiEndpoint_Microservice_MicroserviceId",
                        column: x => x.MicroserviceId,
                        principalTable: "Microservice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowEngineId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BpmnXml = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessInstance_WorkflowEngine_WorkflowEngineId",
                        column: x => x.WorkflowEngineId,
                        principalTable: "WorkflowEngine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DockerComposeService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DockerComposeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Ports = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockerComposeService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DockerComposeService_DockerCompose_DockerComposeId",
                        column: x => x.DockerComposeId,
                        principalTable: "DockerCompose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentVar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KubernetesId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentVar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentVar_Kubernetes_KubernetesId",
                        column: x => x.KubernetesId,
                        principalTable: "Kubernetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersistenVolumeClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KubernetesId = table.Column<int>(type: "integer", nullable: false),
                    RequiredStorage = table.Column<decimal>(type: "numeric", nullable: false),
                    StorageClass = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistenVolumeClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersistenVolumeClaim_Kubernetes_KubernetesId",
                        column: x => x.KubernetesId,
                        principalTable: "Kubernetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BpmnActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityHandlerId = table.Column<int>(type: "integer", nullable: false),
                    ProcessInstanceId = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionTopic = table.Column<string>(type: "text", nullable: true),
                    TimeoutPattern = table.Column<string>(type: "text", nullable: true),
                    TaskType = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BpmnActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BpmnActivity_BpmnActivityHandler_ActivityHandlerId",
                        column: x => x.ActivityHandlerId,
                        principalTable: "BpmnActivityHandler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BpmnActivity_ProcessInstance_ProcessInstanceId",
                        column: x => x.ProcessInstanceId,
                        principalTable: "ProcessInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceToEnvVars",
                columns: table => new
                {
                    DockerComposeServicesId = table.Column<int>(type: "integer", nullable: false),
                    EnvVarsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceToEnvVars", x => new { x.DockerComposeServicesId, x.EnvVarsId });
                    table.ForeignKey(
                        name: "FK_ServiceToEnvVars_DockerComposeService_DockerComposeServices~",
                        column: x => x.DockerComposeServicesId,
                        principalTable: "DockerComposeService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceToEnvVars_EnvironmentVar_EnvVarsId",
                        column: x => x.EnvVarsId,
                        principalTable: "EnvironmentVar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BpmnActivityVar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BpmnActivityId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ValueType = table.Column<string>(type: "text", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BpmnActivityVar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BpmnActivityVar_BpmnActivity_BpmnActivityId",
                        column: x => x.BpmnActivityId,
                        principalTable: "BpmnActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiEndpoint_MicroserviceId",
                table: "ApiEndpoint",
                column: "MicroserviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ConfigurationId",
                table: "Application",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_SolutionId",
                table: "Application",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_BpmnActivity_ActivityHandlerId",
                table: "BpmnActivity",
                column: "ActivityHandlerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BpmnActivity_ProcessInstanceId",
                table: "BpmnActivity",
                column: "ProcessInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_BpmnActivityHandler_ResponsibleApplicationId",
                table: "BpmnActivityHandler",
                column: "ResponsibleApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BpmnActivityVar_BpmnActivityId",
                table: "BpmnActivityVar",
                column: "BpmnActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEntity_DbEngineId",
                table: "DbEntity",
                column: "DbEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEntityField_DbEntityId",
                table: "DbEntityField",
                column: "DbEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DbEntityRelationship_ToEntityId",
                table: "DbEntityRelationship",
                column: "ToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Deployment_ApplicationId",
                table: "Deployment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignPattern_SolutionId",
                table: "DesignPattern",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_DockerComposeService_DockerComposeId",
                table: "DockerComposeService",
                column: "DockerComposeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentVar_KubernetesId",
                table: "EnvironmentVar",
                column: "KubernetesId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ParentFolderId",
                table: "Folder",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_SolutionId",
                table: "Folder",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_GatewayRoute_ApiGatewayId",
                table: "GatewayRoute",
                column: "ApiGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Microservice_DbEngineId",
                table: "Microservice",
                column: "DbEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistenVolumeClaim_KubernetesId",
                table: "PersistenVolumeClaim",
                column: "KubernetesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessInstance_WorkflowEngineId",
                table: "ProcessInstance",
                column: "WorkflowEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceToEnvVars_EnvVarsId",
                table: "ServiceToEnvVars",
                column: "EnvVarsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEngine_SagaPatternId",
                table: "WorkflowEngine",
                column: "SagaPatternId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiEndpoint");

            migrationBuilder.DropTable(
                name: "BpmnActivityVar");

            migrationBuilder.DropTable(
                name: "ClientApplication");

            migrationBuilder.DropTable(
                name: "DbEntityField");

            migrationBuilder.DropTable(
                name: "DbEntityRelationship");

            migrationBuilder.DropTable(
                name: "EventBus");

            migrationBuilder.DropTable(
                name: "FaaS");

            migrationBuilder.DropTable(
                name: "Folder");

            migrationBuilder.DropTable(
                name: "GatewayRoute");

            migrationBuilder.DropTable(
                name: "PersistenVolumeClaim");

            migrationBuilder.DropTable(
                name: "ServiceToEnvVars");

            migrationBuilder.DropTable(
                name: "Microservice");

            migrationBuilder.DropTable(
                name: "BpmnActivity");

            migrationBuilder.DropTable(
                name: "DbEntity");

            migrationBuilder.DropTable(
                name: "ApiGateway");

            migrationBuilder.DropTable(
                name: "DockerComposeService");

            migrationBuilder.DropTable(
                name: "EnvironmentVar");

            migrationBuilder.DropTable(
                name: "BpmnActivityHandler");

            migrationBuilder.DropTable(
                name: "ProcessInstance");

            migrationBuilder.DropTable(
                name: "DbEngine");

            migrationBuilder.DropTable(
                name: "DockerCompose");

            migrationBuilder.DropTable(
                name: "Kubernetes");

            migrationBuilder.DropTable(
                name: "WorkflowEngine");

            migrationBuilder.DropTable(
                name: "Deployment");

            migrationBuilder.DropTable(
                name: "DesignPattern");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "AppConfig");

            migrationBuilder.DropTable(
                name: "Solution");
        }
    }
}
