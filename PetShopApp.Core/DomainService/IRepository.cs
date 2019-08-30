using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IRepository<T>
    {
        T Create(T entity);

        T Read(int id);

        IEnumerable<T> ReadAll();

        T Update(T entity);

        T Delete(int id);
        
    }
}
