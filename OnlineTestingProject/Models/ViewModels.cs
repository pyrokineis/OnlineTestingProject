using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineTestingProject.Models;


namespace OnlineTestingProject.Models
{
    public class TestVM
    {
        public Dictionary<string, string[]> Answers { get; set; }
        public List<KeyValuePair<Question, List<string>>> QuestionsAndOptions { get; set; }
        public Test Test { get; set; }

        //public TestVM()
        //{
        //    Answers = new Dictionary<string, string[] >();
        //    QuestionsAndOptions = new List<KeyValuePair<Question, List<string>>>();

        //}
        public TestVM(Test test)
        {
            Answers = new Dictionary<string, string[]>();
            QuestionsAndOptions = new List<KeyValuePair<Question, List<string>>>();

            Test = test;
        }

        public TestVM Add(Question key, string[] value)
        {
            QuestionsAndOptions.Add(new KeyValuePair<Question, List<string>>(key, value.ToList()));
            return this;
        }
    }
    
}