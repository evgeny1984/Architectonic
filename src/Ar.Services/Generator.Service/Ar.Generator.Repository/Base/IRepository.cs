using Architect.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ar.Generator.Repository.Base
{
    public interface IRepository<T> where T : BaseEntityDto
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithChildrenAsync();
        Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetOneByConditionAsync(Expression<Func<T, bool>> condition);
        Task<T> GetByIdAsync(int id);
        Task<T> GetWithDetailsAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
