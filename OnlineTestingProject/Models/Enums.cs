namespace OnlineTestingProject.Models.Enums
{
    public enum AnswerResult
    {
        Min = 0,
        Half = 1,
        Max = 2,

    }

    public enum QuestionTypes
    {

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