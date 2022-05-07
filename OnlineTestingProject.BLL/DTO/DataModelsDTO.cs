using System;
using System.ComponentModel.DataAnnotations;
using OnlineTestingProject.DAL.Entities;

namespace OnlineTestingProject.BLL.DTO
{
    public class UserDto : ApplicationUser
    {
        
    }
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionTypeDTO Type { get; set; }
    }

    
    public class QuestionTypeDTO
    {
        public int QuestionTypeId { get; set; }
        public string Name { get; set; }
    }
    
    public class UserAnswerDTO
    {
        public int UserAnswerId { get; set; }
        public AnswerTypeDTO AnswerType { get; set; }
        public string Data { get; set; }
    }
    public class Result
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public UserAnswerDTO Answer { get; set; }
        public TestDTO Test { get; set; }
        public bool IsTrue { get; set; }
    }

    public class AnswerTypeDTO
    {
        public int AnswerTypeId { get; set; }

        [MaxLength]
        public string Name { get; set; }
    }

    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }

    public class UsersInGroupDTO
    {   public int UsersInGroupId { get; set; }
        public int UserId { get; set; }
        public int Group { get; set; }
    }

    public class TestDTO
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }

    public class QuestionsInTestDTO
    {
        public int QuestionsInTestId { get; set; }
        public TestDTO Test { get; set; }
        public QuestionDto Question { get; set; }
    }

    public class CorrectAnswerDTO
    {
        public int CorrectAnswerId { get; set; }
        public QuestionDto Question { get; set; }
        public string AnswerData { get; set; }
        
    }
}