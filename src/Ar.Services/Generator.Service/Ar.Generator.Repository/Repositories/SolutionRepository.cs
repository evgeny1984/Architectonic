using Ar.Generator.Data.Models.SolutionAppConfig;
using Ar.Generator.Repository.Helpers;
using Architect.Dto.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ar.Generator.Repository.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private GeneratorDbContext _Context;

        public SolutionRepository(GeneratorDbContext context)
        {
            _Context = context;
        }

        public async Task<int> CreateAsync(SolutionDto entityDto)
        {
            int id = 0;
            var newSolution = AutomapperConfig.Mapper.Map<Solution>(entityDto);
            _Context.Solutions.Add(newSolution);
            id = await _Context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(int id)
        {
            var solution = await _Context.Solutions.SingleOrDefaultAsync(m => m.Id == id);
            if (solution == null)
            {
                throw new Exception($"Solution with id: {id} was not found.");
            }

            _Context.Solutions.Remove(solution);
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SolutionDto>> GetAllAsync()
        {
            var solutions = await _Context.Solutions
                                .ToListAsync();
            var solutionDtos = AutomapperConfig.Mapper.Map<List<SolutionDto>>(solutions);

            return solutionDtos;
        }

        public Task<IEnumerable<SolutionDto>> GetAllByConditionAsync(Expression<Func<SolutionDto, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SolutionDto>> GetAllWithChildrenAsync()
        {
            var solutions = await _Context.Solutions
                           .Include(c => c.Applications)
                           .Include(c => c.Patterns)
                           .Include(c => c.SolutionStructure)
                           .ToListAsync();

            var solutionDtos = AutomapperConfig.Mapper.Map<List<SolutionDto>>(solutions);

            return solutionDtos;
        }

        public async Task<SolutionDto> GetByIdAsync(int id)
        {
            var solution = await _Context.Solutions.FirstOrDefaultAsync(c => c.Id == id);

            var solutionDto = AutomapperConfig.Mapper.Map<SolutionDto>(solution);

            return solutionDto;
        }

        public async Task<IEnumerable<SolutionDto>> GetOneByConditionAsync(Expression<Func<SolutionDto, bool>> condition)
        {
            var entities = await _Context.Solutions.ToListAsync();
            var entitiyDtos = AutomapperConfig.Mapper.Map<List<SolutionDto>>(entities);

            return entitiyDtos.Where(condition.Compile());
        }

        public Task<SolutionDto> GetWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(SolutionDto solution)
        {

            var newSolution = AutomapperConfig.Mapper.Map<Solution>(solution);

            var existingSolution = await _Context.Solutions
                .SingleOrDefaultAsync(r => r.Id == solution.Id);

            if (existingSolution != null)
            {

                _Context.Entry(existingSolution).CurrentValues.SetValues(newSolution);
                await _Context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Solution with ID {existingSolution.Id} was not found.");
            }

            return existingSolution.Id;
        }
    }
}
