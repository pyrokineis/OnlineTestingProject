using System.Collections.Generic;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Services
{
    public class GroupService : IGroupService
    {
        private IUnitOfWork _dbContext { get; set; }

        public GroupService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }
        public List<Group> GetAllGroups()
        {
           return _dbContext.Groups.GetAll();
        }
        public void AssignTestToGroup(Test test, Group group)
        {
            throw new System.NotImplementedException();
        }

        public void AssignTestToUser(Test test, ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public void DeasignTestForGroup(Test test, Group group)
        {
            throw new System.NotImplementedException();
        }

        public void DeasignTestForUser(Test test, ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}