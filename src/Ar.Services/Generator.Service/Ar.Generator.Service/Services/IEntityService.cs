using Architect.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public interface IEntityService<T> where T : BaseEntityDto
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithChildren();
        Task<IEnumerable<T>> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetOneByCondition(Expression<Func<T, bool>> condition);
        Task<T> GetById(int id);
        Task<T> GetWithDetails(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task Delete(int id);
    }
}
