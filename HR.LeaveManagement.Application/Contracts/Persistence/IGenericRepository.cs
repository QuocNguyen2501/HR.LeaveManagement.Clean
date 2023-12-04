﻿using System.Linq.Expressions;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T: BaseEntity
{
    
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetAsyncById(string id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
