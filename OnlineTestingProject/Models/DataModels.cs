using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineTestingProject.Models
{
    public class User : IdentityUser
    {
        
    }
        
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
    }

    public class QuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsTrue { get; set; }
        public AnswerType Type { get; set; }
         
    }

    public class AnswerType
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UsersInGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
    
}