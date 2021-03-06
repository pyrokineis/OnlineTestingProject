using System;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private QuestionRepository _questionRepository;
        private QuestionTypeRepository _questionTypeRepository;
        private TestRepository _testRepository;
        private GroupRepository _groupRepository;
        private TestAssignedGroupRepository _testAssignedGroupRepository;
        private TestAssignedUserRepository _testAssignedUserRepository;
        private UsersInGroupRepository _usersInGroupRepository;
        private UserRepository _userRepository;
        private QuestionsInTestsRepository _questionsInTestsRepository;
        private AnswerOptionRepository _answerOptionRepository;
        private UserAnswerRepository _userAnswerRepository;
        private TestResultRepository _testResultRepository;
        public EfUnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public IRepository<Question> Questions => _questionRepository ?? (_questionRepository = new QuestionRepository(_dbContext));

        public IRepository<QuestionType> QuestionTypes => _questionTypeRepository ?? (_questionTypeRepository = new QuestionTypeRepository(_dbContext));
        public IRepository<Test> Tests => _testRepository ?? (_testRepository = new TestRepository(_dbContext));
        public IRepository<Group> Groups => _groupRepository ?? (_groupRepository = new GroupRepository(_dbContext));
        public IRepository<TestAssignedGroup> TestAssignedGroups => _testAssignedGroupRepository ?? (_testAssignedGroupRepository = new TestAssignedGroupRepository(_dbContext));
        public IRepository<TestAssignedUser> TestAssignedUsers => _testAssignedUserRepository ?? (_testAssignedUserRepository = new TestAssignedUserRepository(_dbContext));
        public IRepository<UsersInGroup> UsersInGroups => _usersInGroupRepository ?? (_usersInGroupRepository = new UsersInGroupRepository(_dbContext));
        public IRepository<ApplicationUser> Users => _userRepository ?? (_userRepository = new UserRepository(_dbContext));
        public IRepository<QuestionsInTest> QuestionsInTests => _questionsInTestsRepository ?? (_questionsInTestsRepository = new QuestionsInTestsRepository(_dbContext));
        public IRepository<AnswersOption> AnswersOptions  => _answerOptionRepository ?? (_answerOptionRepository = new AnswerOptionRepository(_dbContext));
        public IRepository<UserAnswer> UserAnswers => _userAnswerRepository ?? (_userAnswerRepository = new UserAnswerRepository(_dbContext));
        public IRepository<TestResult> TestResults => _testResultRepository ?? (_testResultRepository = new TestResultRepository(_dbContext));



        public void Save()
        {
            _dbContext.SaveChanges();
        }
 
        private bool _disposed = false;

        private protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}