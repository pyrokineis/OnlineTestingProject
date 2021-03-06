using System;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Question> Questions { get;}
        IRepository<QuestionType> QuestionTypes { get; }
        IRepository<Test> Tests { get; }
        IRepository<Group> Groups { get; }
        IRepository<TestAssignedGroup> TestAssignedGroups {get;}
        IRepository<TestAssignedUser> TestAssignedUsers {get;}
        IRepository<UsersInGroup> UsersInGroups { get; }
        IRepository<ApplicationUser> Users { get; }
        IRepository<QuestionsInTest> QuestionsInTests { get; }
        IRepository<AnswersOption> AnswersOptions { get; }
        IRepository<UserAnswer> UserAnswers { get; }
        IRepository<TestResult> TestResults { get; }
        void Save();
    }
}