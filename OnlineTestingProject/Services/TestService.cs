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
            _dbContext.Tests.Save();
        }

        public List<Test> GetAllTests()
        {
            return _dbContext.Tests.GetAll();
        }

        public Test GetTest(int id)
        {
            return _dbContext.Tests.Get(id.ToString());
        }
        

        public List<Group> GetAssignedGroups(Test test)
        {
            var list = _dbContext.TestAssignedGroups.Find(r => r.Test.TestId == test.TestId).Select(r => r.Group).ToList();
            return list;
        }

        public List<ApplicationUser> GetAssignedUsers(Test test)
        {
            // throw new System.NotImplementedException();
            var list = _dbContext.TestAssignedUsers.Find(r => r.Test == test).Select(r => r.UserId).ToList();
            List<ApplicationUser> list2 = new List<ApplicationUser>();
            foreach (string Id in list)
            {
                list2.Add(_dbContext.Users.Get(Id));
            }
            return list2;
        }

        public void AssignUserForTest(ApplicationUser user, Test test)
        {
            _dbContext.TestAssignedUsers.Add(new TestAssignedUser
            {
                UserId = user.Id,
                Test = test
            });
            _dbContext.TestAssignedUsers.Save();
        }
        public void AssignGroupForTest(Group gr, Test test)
        {
            _dbContext.TestAssignedGroups.Add(new TestAssignedGroup
            {
                Test = test,
                Group = gr
            });
            _dbContext.TestAssignedGroups.Save();
        }

        public void DeasignUserFromTest(ApplicationUser user, Test test)
        {
            throw new NotImplementedException();
        }

        public void DeasignGroupFromTest(Group gr, Test test)
        {
            throw new NotImplementedException();
        }
    }
}