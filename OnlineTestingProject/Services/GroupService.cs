using System.Collections.Generic;
using System.Linq;
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
        public Group GetGroup(int id)
        {
           return _dbContext.Groups.Get(id.ToString());
        }
        public List<ApplicationUser> GetUsersInGroup(int id)
        {
            var list = _dbContext.UsersInGroups.GetAll().Where(g => g.GroupId == id).Select(g => g.UserId).ToList();
            List<ApplicationUser> list2 = new List<ApplicationUser>();
            foreach (string Id in list)
            {
                list2.Add(_dbContext.Users.Get(Id));
            }
            return list2;
            // throw new System.NotImplementedException();
        }
        public Group GetGroupByName(string name)
        {
            var list = _dbContext.Groups.Find(r => r.Name == name).FirstOrDefault();
            return list;
        }

        public void AddGroup(Group gr)
        {
            _dbContext.Groups.Add(gr);
            _dbContext.Save();
        }

        public void DeleteGroup(int id)
        {
            _dbContext.Groups.Delete(id);
            _dbContext.Save();
        }

        public List<Group> GetUserGroups(string userId)
        {
            var list = _dbContext.UsersInGroups.Find(r=>r.UserId==userId);
            List<Group> list2 = new List<Group>();


            foreach (var obj in list)
            {
                list2.Add(_dbContext.Groups.Get(obj.GroupId.ToString()));
            }
            return list2;
        }
    }
}