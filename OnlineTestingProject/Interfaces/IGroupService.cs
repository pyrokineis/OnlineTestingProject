using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Interfaces
{
    public interface IGroupService
    {
        List<Group> GetAllGroups();
        void AddGroup(Group gr);
        List<ApplicationUser> GetUsersInGroup(int id);
        Group GetGroup(int id);
        Group GetGroupByName(string name);
        List<Group> GetUserGroups(string userId);
    }
}