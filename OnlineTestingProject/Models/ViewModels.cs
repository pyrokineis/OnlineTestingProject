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
        public List<KeyValuePair<Question, List<AnswersOption>>> QuestionsAndOptions { get; set; }

        public Test Test { get; set; }
        public TestResult Result { get; set; }

        public TestVM()
        {
            Answers = new Dictionary<string, string[]>();
            QuestionsAndOptions = new List<KeyValuePair<Question, List<AnswersOption>>>();

        }
        public TestVM(Test test)
        {
            Answers = new Dictionary<string, string[]>();
            QuestionsAndOptions = new List<KeyValuePair<Question, List<AnswersOption>>>();

            Test = test;
        }

        public TestVM Add(Question key, List<AnswersOption> value)
        {
            QuestionsAndOptions.Add(new KeyValuePair<Question, List<AnswersOption>>(key, value));
            return this;
        }
    }


    public class TeacherPageVM
    {
        public Test test { get; set; }
        public Group group { get; set; }
        public List<Test> teacherTests { get; set; }
        public List<Group> teacherGroups { get; set; }

    }
}