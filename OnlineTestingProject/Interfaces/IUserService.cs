using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingProject.Interfaces
{
    public interface IUserService
    {
        List<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string id);
        ApplicationUser GetUserByUsername(string username);
        ApplicationUser GetUserByFullName(string line);
        void AddUserToGroup(ApplicationUser user, Group gr);
        void AddUserToGroup(ApplicationUser user, int grId);
    }
}
