using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface IRepository<T>
    {
        void Update(T entity);
        IQueryable<T> List();
    }
}
