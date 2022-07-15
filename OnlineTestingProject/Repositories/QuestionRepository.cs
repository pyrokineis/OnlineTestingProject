using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private ApplicationDbContext _dbContext;

        public QuestionRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<Question> GetAll()
        {
            return _dbContext.Questions.ToList();
        }


        public Question Get(string id)
        {
            return _dbContext.Questions.Find(Int32.Parse(id));
        }

        public void Create(Question qst)
        {
            _dbContext.Questions.Add(qst);
        }
 
        public void Update(Question qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }
 
        public IEnumerable<Question> Find(Func<Question, Boolean> predicate)
        {
            return _dbContext.Questions.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            Question qst = _dbContext.Questions.Find(id);
            if (qst != null)
            {
                //foreach(var opt in _dbContext.AnswersOptions.Where(x => x.QuestionId == id))
                //{
                //    _dbContext.AnswersOptions.Remove(opt);
                //}
                _dbContext.Questions.Remove(qst);
            }
        }

        public void Add(Question item)
        {
            _dbContext.Questions.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(Question item)
        {
            _dbContext.Questions.Attach(item);
        }
    }
}