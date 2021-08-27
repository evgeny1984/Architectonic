using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Ar.Generator.Data.Models.Deployments;
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
                cfg.CreateMap<Application, ApplicationDto>()
                    .ReverseMap();

                cfg.CreateMap<BpmnActivityHandler, BpmnActivityHandlerDto>()
                   .ReverseMap();

                cfg.CreateMap<Deployment, DeploymentDto>()
                  .ReverseMap();

                cfg.CreateMap<DesignPattern, DesignPatternDto>()
                  .ReverseMap();

                cfg.CreateMap<Folder, FolderDto>()
                  .ReverseMap();

                cfg.CreateMap<Solution, SolutionDto>()
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
