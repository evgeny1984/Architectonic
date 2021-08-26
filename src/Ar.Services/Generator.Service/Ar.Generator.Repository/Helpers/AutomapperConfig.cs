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
                //cfg.CreateMap<Address, AddressDTO>()
                //    .ReverseMap();

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
