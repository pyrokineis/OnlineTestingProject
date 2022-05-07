using System.Collections.Generic;
using OnlineTestingProject.BLL.DTO;

namespace OnlineTestingProject.BLL.Interfaces
{
    public interface IQuestionService
    {
        List<QuestionDto> GetAnswers();
    }
}