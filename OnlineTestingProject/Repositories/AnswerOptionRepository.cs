using OnlineTestingProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTestingProject.Models;
using System.Data.Entity;

namespace OnlineTestingProject.Repositories
{
    public class AnswerOptionRepository : IRepository<AnswersOption>
    {
        private ApplicationDbContext _dbContext;

        public AnswerOptionRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public List<AnswersOption> GetAll()
        {
            return _dbContext.AnswersOptions.ToList();
        }

        public AnswersOption Get(string id)
        {
            return _dbContext.AnswersOptions.Find(Int32.Parse(id));
        }

        public void Create(AnswersOption gr)
        {
            _dbContext.AnswersOptions.Add(gr);
        }

        public void Update(AnswersOption gr)
        {
            _dbContext.Entry(gr).State = EntityState.Modified;
        }

        public IEnumerable<AnswersOption> Find(Func<AnswersOption, Boolean> predicate)
        {
            return _dbContext.AnswersOptions.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            AnswersOption gr = _dbContext.AnswersOptions.Find(id);
            if (gr != null)
                _dbContext.AnswersOptions.Remove(gr);
        }

        public void Add(AnswersOption gr)
        {
            _dbContext.AnswersOptions.Add(gr);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Attach(AnswersOption item)
        {
            _dbContext.AnswersOptions.Attach(item);
        }
    }
}