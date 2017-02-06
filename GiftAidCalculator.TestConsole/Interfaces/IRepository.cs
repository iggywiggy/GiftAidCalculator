using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface IRepository<T>
    {
        T Update(T entity);
        IEnumerable<T> Select(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
    }
}