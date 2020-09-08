using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Common.Lib.Core.Context
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IQueryable<T> QueryAll();

        T Find(Guid id);

        SaveResult<T> Add(T entity);

        SaveResult<T> Update(T entity);

        SaveResult<T> Delete(T entity);
    }
}
