using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class TestAssignedGroupRepository : IRepository<TestAssignedGroup>
    {
        private ApplicationDbContext _dbContext;

        public TestAssignedGroupRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<TestAssignedGroup> GetAll()
        {
            return _dbContext.TestAssignedGroups.ToList();
        }


        public TestAssignedGroup Get(string id)
        {
            return _dbContext.TestAssignedGroups.Find(Int32.Parse(id));
        }

        public void Create(TestAssignedGroup qst)
        {
            _dbContext.TestAssignedGroups.Add(qst);
        }
 
        public void Update(TestAssignedGroup qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }
 
        public IEnumerable<TestAssignedGroup> Find(Func<TestAssignedGroup, Boolean> predicate)
        {
            return _dbContext.TestAssignedGroups.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            TestAssignedGroup qst = _dbContext.TestAssignedGroups.Find(id);
            if (qst != null)
                _dbContext.TestAssignedGroups.Remove(qst);
        }

        public void Add(TestAssignedGroup item)
        {
            _dbContext.TestAssignedGroups.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(TestAssignedGroup item)
        {
            _dbContext.TestAssignedGroups.Attach(item);
        }
    }
}