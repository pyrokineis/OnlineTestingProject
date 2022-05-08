using System;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Question> Questions { get;}
        void Save();
    }
}