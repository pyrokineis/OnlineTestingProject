using System;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Question> Questions { get;}
        IRepository<QuestionType> QuestionTypes { get; }
        IRepository<Test> Tests { get; }

        void Save();
    }
}