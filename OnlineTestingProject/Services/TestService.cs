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
        private readonly IGroupService _groupService;
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
            var list = _dbContext.TestAssignedGroups.Find(r => r.TestId == test.Id).Select(r => r.GroupId).ToList();
            List<Group> list2 = new List<Group>();
            foreach (int id in list)
            {
                list2.Add(_dbContext.Groups.Get(id.ToString()));
            }
            return list2;
        }

        public List<ApplicationUser> GetAssignedUsers(Test test)
        {
            // throw new System.NotImplementedException();
            var list = _dbContext.TestAssignedUsers.Find(r => r.TestId == test.Id).Select(r => r.UserId).ToList();
            List<ApplicationUser> list2 = new List<ApplicationUser>();
            foreach (string Id in list)
            {
                list2.Add(_dbContext.Users.Get(Id));
            }
            return list2;
        }

        public void AssignUserForTest(ApplicationUser user, Test test)
        {
            if (_dbContext.TestAssignedUsers.GetAll().Find(r => r.UserId == user.Id && r.TestId == test.Id) != null)
                return;

            _dbContext.TestAssignedUsers.Add(new TestAssignedUser
            {
                UserId = user.Id,
                TestId = test.Id
            });
            _dbContext.TestAssignedUsers.Save();
        }
        public void AssignGroupForTest(Group gr, Test test)
        {
            _dbContext.TestAssignedGroups.Add(new TestAssignedGroup
            {
                TestId = test.Id,
                GroupId = gr.Id
            });
            _dbContext.TestAssignedGroups.Save();
        }

        public void DeasignUserFromTest(ApplicationUser user, Test test)
        {
            var list = _dbContext.TestAssignedUsers.Find(r => r.UserId == user.Id && r.TestId == test.Id);

            if (list == null)
                return;

            foreach (var item in list)
                _dbContext.TestAssignedUsers.Delete(item.Id);

            _dbContext.TestAssignedUsers.Save();
        }

        public void DeasignGroupFromTest(Group gr, Test test)
        {
            throw new NotImplementedException();
        }

        public void AddQuestionToTest(Test test, Question qst)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsInTest(Test test)
        {
            var list = _dbContext.QuestionsInTests.GetAll();
            List<Question> list2 = new List<Question>();

            foreach (var item in list)
                list2.Add(_dbContext.Questions.Get(item.Question.Id.ToString()));

            return list2;

        }

        public List<Test> GetTestsAssignedDirectlyToUser(string userId)
        {
            var list = _dbContext.TestAssignedUsers.Find(r => r.UserId == userId);


            var list2 = new List<Test>();

            foreach (var obj in list)
            {
                list2.Add(_dbContext.Tests.Get(obj.TestId.ToString()));
            }
            return list2;
        }

        public List<Test> GetTestsAssignedToUsersGroups(List<Group> userGroups)
        {
            var list2 = new List<Test>();
            var list =_dbContext.TestAssignedGroups.GetAll().Where(r=> userGroups.Select(x=>x.Id).Contains(r.GroupId));
            

            foreach (var gr in list)
            {
                list2.Add(_dbContext.Tests.Get(gr.TestId.ToString()));
            }
            return list2;
        }

        public List<Question> getQuestionsInTest(Test test)
        {
            throw new NotImplementedException();
        }


    }
}