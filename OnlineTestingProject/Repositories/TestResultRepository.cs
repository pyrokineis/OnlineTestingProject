using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class TestResultRepository : IRepository<TestResult>
    {
        private ApplicationDbContext _dbContext;

        public TestResultRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<TestResult> GetAll()
        {
            return _dbContext.TestResults.ToList();
        }

        public TestResult Get(string id)
        {
            return _dbContext.TestResults.Find(Int32.Parse(id));
        }

        public void Create(TestResult gr)
        {
            _dbContext.TestResults.Add(gr);
        }

        public void Update(TestResult gr)
        {
            _dbContext.Entry(gr).State = EntityState.Modified;
        }

        public IEnumerable<TestResult> Find(Func<TestResult, Boolean> predicate)
        {
            return _dbContext.TestResults.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TestResult gr = _dbContext.TestResults.Find(id);
            if (gr != null)
                _dbContext.TestResults.Remove(gr);
        }

        public void Add(TestResult gr)
        {
            _dbContext.TestResults.Add(gr);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(TestResult item)
        {
            _dbContext.TestResults.Attach(item);
        }
    }
}