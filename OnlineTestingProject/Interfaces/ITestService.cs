using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Interfaces
{
    public interface ITestService
    {
        void AddTest(Test qst);
        void DeleteTest(int id);
        Test GetTest(int id);
        void Update(Test test);
        List<Test> GetAllTests();
        List<Group> GetAssignedGroups(Test test);
        List<Question> GetQuestionsInTest(Test test);
        List<ApplicationUser> GetAssignedUsers(Test test);
        void AssignUserForTest(ApplicationUser user, Test test);
        void AssignGroupForTest(Group gr, Test test);
        void DeasignUserFromTest(ApplicationUser user, Test test);
        void DeasignGroupFromTest(Group gr, Test test);
        void AddQuestionToTest(Test test, Question qst);
        List<Test> GetTestsAssignedDirectlyToUser(string userId);
        List<Test> GetTestsAssignedToUsersGroups(List<Group> userGroups);
    }
}