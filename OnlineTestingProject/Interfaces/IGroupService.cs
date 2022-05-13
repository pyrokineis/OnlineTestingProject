using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Interfaces
{
    public interface IGroupService
    {
        List<Group> GetAllGroups();
        void AssignTestToGroup(Test test, Group group);
        void DeasignTestForGroup(Test test, Group group);
        void AssignTestToUser(Test test, ApplicationUser user);
        void DeasignTestForUser(Test test, ApplicationUser user);
    }
}