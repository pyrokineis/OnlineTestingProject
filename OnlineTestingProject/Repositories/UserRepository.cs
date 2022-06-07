using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Repositories
{
    public class UserRepository : IRepository<ApplicationUser>
    {
        private ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<ApplicationUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public ApplicationUser Get(string id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Create(ApplicationUser qst)
        {
            _dbContext.Users.Add(qst);
        }

        public void Update(ApplicationUser qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate)
        {
            return _dbContext.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ApplicationUser user = _dbContext.Users.Find(id);
            if (user != null)
                _dbContext.Users.Remove(user);
        }

        public void Add(ApplicationUser item)
        {
            _dbContext.Users.Add(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(ApplicationUser item)
        {
            _dbContext.Users.Attach(item);
        }
    }
}