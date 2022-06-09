using System;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Models
{

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TypeId { get; set; }
        public QuestionsTheme Theme { get; set; }
        public string AnswerData { get; set; }

    }

    public class QuestionsInTest
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public int QuestionId { get; set; }
    }
    
    public class QuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class UserAnswer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Question Question { get; set; }
        public Test Test { get; set; }
        public string Data { get; set; }
        public AnswerResult Result { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UsersInGroup
    {   public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
    }
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TestStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FinishDate { get; set; }
        public string CreatorLogin { get; set; }
        public  TestTheme Theme { get; set; }
    }

    public class AnswersOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
    }

    public class TestAssignedGroup
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int GroupId { get; set; }
    }

    public class TestAssignedUser
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }
    }
    
}