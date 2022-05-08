using System;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private QuestionRepository _questionRepository;

        public EfUnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public IRepository<Question> Questions => _questionRepository ?? (_questionRepository = new QuestionRepository(_dbContext));
        public void Save()
        {
            _dbContext.SaveChanges();
        }
 
        private bool _disposed = false;

        private protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}