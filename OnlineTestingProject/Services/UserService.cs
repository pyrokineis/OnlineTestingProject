using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace OnlineTestingProject.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _dbContext { get; set; }

        public UserService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _dbContext.Users.Get(id);
        }
        public List<ApplicationUser> GetAllUsers()
        {
           return _dbContext.Users.GetAll();
        }

        public void AddUserToGroup(ApplicationUser user, Group gr)
        {
            _dbContext.UsersInGroups.Add(new UsersInGroup
            {
                UserId = user.Id,
                GroupId = gr.Id
            });
        }
        public void AddUserToGroup(ApplicationUser user, int grId)
        {
            
            _dbContext.UsersInGroups.Add(new UsersInGroup
            {
                UserId = user.Id,
                GroupId = grId
            });
            _dbContext.UsersInGroups.Save();
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return _dbContext.Users.Find(r=>r.UserName==username).FirstOrDefault();
        }

        public ApplicationUser GetUserByFullName(string line)
        {
            return _dbContext.Users.Find(r=>r.Firstname +" "+ r.Surname==line).FirstOrDefault();
        }
    }
}