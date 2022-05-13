using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private ApplicationDbContext _dbContext;

        public GroupRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }
        
        public Group Get(int id)
        {
            return _dbContext.Groups.Find(id);
        }

        public void Create(Group gr)
        {
            _dbContext.Groups.Add(gr);
        }
 
        public void Update(Group gr)
        {
            _dbContext.Entry(gr).State = EntityState.Modified;
        }
 
        public IEnumerable<Group> Find(Func<Group, Boolean> predicate)
        {
            return _dbContext.Groups.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            Group gr = _dbContext.Groups.Find(id);
            if (gr != null)
                _dbContext.Groups.Remove(gr);
        }

        public void Add(Group gr)
        {
            _dbContext.Groups.Add(gr);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}