using OnlineTestingProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTestingProject.Models;
using System.Data.Entity;

namespace OnlineTestingProject.Repositories
{
    public class QuestionTypeRepository : IRepository<QuestionType>
    {
        private ApplicationDbContext _dbContext;

        public QuestionTypeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public List<QuestionType> GetAll()
        {
            return _dbContext.QuestionTypes.ToList();
        }


        public QuestionType Get(int id)
        {
            return _dbContext.QuestionTypes.Find(id);
        }

        public void Create(QuestionType qst)
        {
            _dbContext.QuestionTypes.Add(qst);
        }

        public void Update(QuestionType qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }

        public IEnumerable<QuestionType> Find(Func<QuestionType, Boolean> predicate)
        {
            return _dbContext.QuestionTypes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            QuestionType test = _dbContext.QuestionTypes.Find(id);
            if (test != null)
                _dbContext.QuestionTypes.Remove(test);
        }

        public void Add(QuestionType item)
        {
            _dbContext.QuestionTypes.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}