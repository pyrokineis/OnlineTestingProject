using System.Collections;
using System.Collections.Generic;

namespace OnlineTestingProject.Models.Enums
{
    public enum AnswerResult
    {
        Min = 0,
        Half = 1,
        Max = 2,

    }
    public enum QuestionsTypes
    {
        Тестовый = 1,
        НесколькоВариатов = 2,
        Текстовый = 3,
        Порядок = 4
    }


    public enum TestStatus
    {
        NotStarted,
        InProgress, 
        Finished,
    }
    
    public enum TestTheme
    {
        Overall,
        Math,
        RussLanguage,
        EngLanguage,
        Physics
    }

    public enum QuestionsTheme 
    { 
        NoTheme,
        SchoolMath,
        SchoolRussLang,
        SchoolEngLang
    }

}