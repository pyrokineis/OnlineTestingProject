using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Repositories
{
    public class UserAnswerRepository : IRepository<UserAnswer>
    {
        private ApplicationDbContext _dbContext;
        public UserAnswerRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<UserAnswer> GetAll()
        {
            return _dbContext.UserAnswers.ToList();
        }

        public UserAnswer Get(string id)
        {
            return _dbContext.UserAnswers.Find(id);
        }

        public void Create(UserAnswer qst)
        {
            _dbContext.UserAnswers.Add(qst);
        }

        public void Update(UserAnswer qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }

        public IEnumerable<UserAnswer> Find(Func<UserAnswer, Boolean> predicate)
        {
            return _dbContext.UserAnswers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserAnswer user = _dbContext.UserAnswers.Find(id);
            if (user != null)
                _dbContext.UserAnswers.Remove(user);
        }

        public void Add(UserAnswer item)
        {
            _dbContext.UserAnswers.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(UserAnswer item)
        {
            _dbContext.UserAnswers.Attach(item);
        }
    }
}