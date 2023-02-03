using Ardalis.Specification;
using HexTest.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HexTest.SharedKernel.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity 
{
  Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
  
  Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,string includeProperties = "");

  Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);

  Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

  //Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

  Task<T> AddAsync(T entity, CancellationToken cancellationToken);

  Task UpdateAsync(T entity, CancellationToken cancellationToken);

  Task DeleteAsync(T entity, CancellationToken cancellationToken);

  //Task<int> CountAsync(ISpecification<T> spec);
}
