using System;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineTestingProject.Models
{

    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
    }

    public class QuestionType
    {
        public int QuestionTypeId { get; set; }
        public string Name { get; set; }
    }
    
    public class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public AnswerType AnswerType { get; set; }
        public string Data { get; set; }
    }
    public class Result
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public UserAnswer Answer { get; set; }
        public Test Test { get; set; }
        public bool IsTrue { get; set; }
    }

    public class AnswerType
    {
        public int AnswerTypeId { get; set; }
        public string Name { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }

    public class UsersInGroup
    {   public int UsersInGroupId { get; set; }
        public int UserId { get; set; }
        public int Group { get; set; }
    }

    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public User Author { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }

    public class QuestionsInTest
    {
        public int QuestionsInTestId { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
    }

    public class CorrectAnswer
    {
        public int CorrectAnswerId { get; set; }
        public Question Question { get; set; }
        public string AnswerData { get; set; }
        
    }
}