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
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public string AnswerData { get; set; }

    }

    public class QuestionsInTest
    {
        public int QuestionsInTestId { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
    }
    
    public class QuestionType
    {
        public int QuestionTypeId { get; set; }
        public string Name { get; set; }
    }
    
    public class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public string UserId { get; set; }
        public Question Question { get; set; }
        public Test Test { get; set; }
        public string Data { get; set; }
        public AnswerResult Result { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
    public class UsersInGroup
    {   public int UsersInGroupId { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
    }
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }

    public class TestAssignedGroup
    {
        public int TestAssignedGroupId { get; set; }
        public Test Test { get; set; }
        public Group Group { get; set; }
    }

    public class TestAssignedUser
    {
        public int TestAssignedUserId { get; set; }
        public Test Test { get; set; }
        public string UserId { get; set; }
    }
    

    
}