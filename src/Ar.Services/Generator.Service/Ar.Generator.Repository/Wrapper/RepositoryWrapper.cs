using Ar.Generator.Repository.Helpers;
using Ar.Generator.Repository.Repositories;
using AutoMapper;
using System;

namespace Ar.Generator.Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private GeneratorDbContext _Context;
        private ISolutionRepository _Solution;

        public RepositoryWrapper(GeneratorDbContext context)
        {
            _Context = context;
            try
            {
                // Execute the initial auto mapper configuration
                AutomapperConfig.Configure();
                AutomapperConfig.Mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Entity repositories

        public ISolutionRepository Solution
        {
            get
            {
                if (_Solution == null)
                {
                    _Solution = new SolutionRepository(_Context);
                }

                return _Solution;
            }
        }

        #endregion

    }
}
