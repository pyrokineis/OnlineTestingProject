using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Services
{
    public class TestService : ITestService
    {
        private IUnitOfWork _dbContext { get; set; }

        public TestService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }
        public void AddTest(Test test)
        {
            _dbContext.Tests.Add(test);
        }

        public List<Test> GetAllTests()
        {
            return _dbContext.Tests.GetAll();
        }

        public Test GetTest(int id)
        {
            return _dbContext.Tests.Get(id);
        }
        

        public List<Group> GetAssignedGroups(Test test)
        {
            return _dbContext.TestAssignedGroups.Find(r => r.Test == test).Select(r=>r.Group).ToList();
        }

        public List<int> GetAssignedUsers(Test test)
        {
            return _dbContext.TestAssignedUsers.Find(r => r.Test == test).Select(r=>r.UserId).ToList();
        }
    }
}