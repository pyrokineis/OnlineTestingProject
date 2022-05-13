using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class TestAssignedUserRepository : IRepository<TestAssignedUser>
    {
        private ApplicationDbContext _dbContext;

        public TestAssignedUserRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<TestAssignedUser> GetAll()
        {
            return _dbContext.TestAssignedUsers.ToList();
        }


        public TestAssignedUser Get(int id)
        {
            return _dbContext.TestAssignedUsers.Find(id);
        }

        public void Create(TestAssignedUser qst)
        {
            _dbContext.TestAssignedUsers.Add(qst);
        }
 
        public void Update(TestAssignedUser qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }
 
        public IEnumerable<TestAssignedUser> Find(Func<TestAssignedUser, Boolean> predicate)
        {
            return _dbContext.TestAssignedUsers.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            TestAssignedUser qst = _dbContext.TestAssignedUsers.Find(id);
            if (qst != null)
                _dbContext.TestAssignedUsers.Remove(qst);
        }

        public void Add(TestAssignedUser item)
        {
            _dbContext.TestAssignedUsers.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}