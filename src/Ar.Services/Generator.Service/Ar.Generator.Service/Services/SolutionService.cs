using Ar.Generator.Repository.Wrapper;
using Architect.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public class SolutionService : ISolutionService
    {
        private IRepositoryWrapper _RepositoryWrapper;

        public SolutionService(IRepositoryWrapper repositoryWrapper)
        {
            _RepositoryWrapper = repositoryWrapper;
        }

        public async Task<int> Create(SolutionDto solution)
        {
            var id = await _RepositoryWrapper.Solution.CreateAsync(solution);

            return id;
        }

        public async Task Delete(int id)
        {
            await _RepositoryWrapper.Solution.DeleteAsync(id);
        }

        public async Task<IEnumerable<SolutionDto>> GetAll()
        {
            var solutions = await _RepositoryWrapper.Solution.GetAllAsync();

            return solutions;
        }

        public async Task<IEnumerable<SolutionDto>> GetAllByCondition(Expression<Func<SolutionDto, bool>> condition)
        {
            return await _RepositoryWrapper.Solution.GetAllByConditionAsync(condition);
        }

        public async Task<IEnumerable<SolutionDto>> GetAllWithChildren()
        {
            var solutions = await _RepositoryWrapper.Solution.GetAllWithChildrenAsync();

            return solutions;
        }

        public async Task<SolutionDto> GetById(int id)
        {
            var solution = await _RepositoryWrapper.Solution.GetByIdAsync(id);

            return solution;
        }

        public async Task<IEnumerable<SolutionDto>> GetOneByCondition(Expression<Func<SolutionDto, bool>> condition)
        {
            return await _RepositoryWrapper.Solution.GetOneByConditionAsync(condition);
        }

        public async Task<SolutionDto> GetWithDetails(int id)
        {
            return await _RepositoryWrapper.Solution.GetWithDetailsAsync(id);
        }

        public async Task<int> Update(SolutionDto company)
        {
            var id = await _RepositoryWrapper.Solution.UpdateAsync(company);

            return id;
        }

    }
}
