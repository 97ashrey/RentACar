using System;

namespace RentACarLibrary.DataAccess
{
    public interface IDataConnection<T> 
    {
        T Get(int id);
        T[] GetAll();
        T[] Filter(Func<T, bool> expression);
        T Create(T data);
        T Delete(int id);
        T Update(T data);
    }
}
