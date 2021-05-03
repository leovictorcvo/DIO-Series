using Console_in_memory_repository.Entities;
using System.Collections.Generic;

namespace Console_in_memory_repository.Data.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> getAll();
        T getById(int id);
        void Save(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        int GetNextId();
    }
}
