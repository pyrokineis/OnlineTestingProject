using System;
using System.Collections.Generic;
using Antlr.Runtime;

namespace OnlineTestingProject.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(string id);
        void Add(T item);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}