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
        Test GetTest(int id);
        List<Test> GetAllTests();
        List<Group> GetAssignedGroups(Test test);
        List<ApplicationUser> GetAssignedUsers(Test test);
        void AssignUserForTest(ApplicationUser user, Test test);
        void AssignGroupForTest(Group gr, Test test);
        void DeasignUserFromTest(ApplicationUser user, Test test);
        void DeasignGroupFromTest(Group gr, Test test);
    }
}