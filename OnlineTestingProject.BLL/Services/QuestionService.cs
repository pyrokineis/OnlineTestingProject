using System.Collections.Generic;
using System.Linq;
using OnlineTestingProject.BLL.DTO;
using OnlineTestingProject.BLL.Interfaces;
using OnlineTestingProject.DAL.DataContext;

namespace OnlineTestingProject.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private ApplicationDbContext DbContext { get; set; }

        public QuestionService(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public List<QuestionDto> GetAnswers()
        {
            List<QuestionDto> list = new List<QuestionDto>();
            foreach (var question in DbContext.Questions.ToList())
            {
                list.Add(new QuestionDto()
                {
                    QuestionId = question.QuestionId,
                    Text = question.Text,
                    // Type = question.Type
                });

            }
            return list;
        }
    }
}