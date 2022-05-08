using System;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private QuestionRepository _questionRepository;
        private QuestionTypeRepository _questionTypeRepository;
        private TestRepository _testRepository;

        public EfUnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public IRepository<Question> Questions => _questionRepository ?? (_questionRepository = new QuestionRepository(_dbContext));

        public IRepository<QuestionType> QuestionTypes => _questionTypeRepository ?? (_questionTypeRepository = new QuestionTypeRepository(_dbContext));
        public IRepository<Test> Tests => _testRepository ?? (_testRepository = new TestRepository(_dbContext));
        //public IRepository<Question> Questions
        //{
        //    get
        //    {
        //        if (_questionRepository == null)
        //            _questionRepository = new QuestionRepository(_dbContext);
        //        return _questionRepository;
        //    }
        //}
        //public IRepository<QuestionType> QuestionTypes
        //{
        //    get
        //    {
        //        if (_questionTypeRepository == null)
        //            _questionTypeRepository = new QuestionTypeRepository(_dbContext);
        //        return _questionTypeRepository;
        //    }
        //}

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