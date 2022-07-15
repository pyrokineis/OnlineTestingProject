using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Repositories
{
    public class TestRepository : IRepository<Test>
    {
        private ApplicationDbContext _dbContext;
        public TestRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<Test> GetAll()
        {
            return _dbContext.Tests.ToList();
        }

        public Test Get(string id)
        {
            return _dbContext.Tests.Find(Int32.Parse(id));
        }

        public void Create(Test qst)
        {
            _dbContext.Tests.Add(qst);
        }

        public void Update(Test qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }

        public IEnumerable<Test> Find(Func<Test, Boolean> predicate)
        {
            return _dbContext.Tests.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Test test = _dbContext.Tests.Find(id);

            if (test != null)
            {
                _dbContext.TestAssignedUsers.RemoveRange(_dbContext.TestAssignedUsers.Where(x => x.TestId == id));
                _dbContext.TestAssignedGroups.RemoveRange(_dbContext.TestAssignedGroups.Where(x => x.TestId == id));
                _dbContext.QuestionsInTests.RemoveRange(_dbContext.QuestionsInTests.Where(x => x.TestId == test.Id));
                _dbContext.Tests.Remove(test);
            }



        }

        public void Add(Test item)
        {
            item.CreationDate = DateTime.Now;
            item.Deadline = DateTime.Now;
            _dbContext.Tests.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(Test item)
        {
            _dbContext.Tests.Attach(item);
        }
    }
}