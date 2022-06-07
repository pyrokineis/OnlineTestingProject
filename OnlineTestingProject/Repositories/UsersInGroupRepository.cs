using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Repositories
{
    public class UsersInGroupRepository : IRepository<UsersInGroup>
    {
        private ApplicationDbContext _dbContext;
        public UsersInGroupRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<UsersInGroup> GetAll()
        {
            return _dbContext.UsersInGroups.ToList();
        }


        public UsersInGroup Get(string id)
        {
            return _dbContext.UsersInGroups.Find(id);
        }

        public void Create(UsersInGroup qst)
        {
            _dbContext.UsersInGroups.Add(qst);
        }

        public void Update(UsersInGroup qst)
        {
            _dbContext.Entry(qst).State = EntityState.Modified;
        }

        public IEnumerable<UsersInGroup> Find(Func<UsersInGroup, Boolean> predicate)
        {
            return _dbContext.UsersInGroups.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UsersInGroup gr = _dbContext.UsersInGroups.Find(id);
            if (gr != null)
                _dbContext.UsersInGroups.Remove(gr);
        }

        public void Add(UsersInGroup item)
        {
            _dbContext.UsersInGroups.Add(item);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(UsersInGroup item)
        {
            _dbContext.UsersInGroups.Attach(item);
        }
    }
}
