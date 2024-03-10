class QuestionsCollection {
    private static string[] mQuestionString = {
        "What month do Christians celebrate Christmas?",
        "What exact date do couples celebrate valentines day in February?",
        "When do we celebrate Halloween?"
    };

    private static string[] mQuestionRightAnswer = {
        "December",
        "14",
        "November"
    }; 

    private static string[][] mQuestionSelection = {
        new string[] {"November", "December", "October", "September"},
        new string[] {"11", "7", "14", "29"},
        new string[] {"December", "June", "October", "November"},
    };


    public static int QuestionCount(){
        return mQuestionString.Length;
    }

    public static QuestionModel GetQuestionByQuestionNumber(int questionNumber){
        return new QuestionModel(
            mQuestionString[questionNumber], 
            mQuestionRightAnswer[questionNumber], 
            mQuestionSelection[questionNumber]
        );
    }
}