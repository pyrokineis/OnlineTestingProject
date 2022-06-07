using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Repositories
{
    public class QuestionsInTestsRepository : IRepository<QuestionsInTest>
    {
        private ApplicationDbContext _dbContext;

        public QuestionsInTestsRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<QuestionsInTest> GetAll()
        {
            return _dbContext.QuestionsInTests.ToList();
        }

        public QuestionsInTest Get(string id)
        {
            return _dbContext.QuestionsInTests.Find(Int32.Parse(id));
        }

        public void Create(QuestionsInTest gr)
        {
            _dbContext.QuestionsInTests.Add(gr);
        }

        public void Update(QuestionsInTest gr)
        {
            _dbContext.Entry(gr).State = EntityState.Modified;
        }

        public IEnumerable<QuestionsInTest> Find(Func<QuestionsInTest, Boolean> predicate)
        {
            return _dbContext.QuestionsInTests.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            QuestionsInTest gr = _dbContext.QuestionsInTests.Find(id);
            if (gr != null)
                _dbContext.QuestionsInTests.Remove(gr);
        }

        public void Add(QuestionsInTest gr)
        {
            _dbContext.QuestionsInTests.Add(gr);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(QuestionsInTest item)
        {
            _dbContext.QuestionsInTests.Attach(item);
        }
    }
}