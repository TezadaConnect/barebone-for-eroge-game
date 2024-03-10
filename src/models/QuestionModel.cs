
class QuestionModel{
    private string mQuestion;
    private string mRightAnswer;
    private string[] mQuestionSelection;

    public QuestionModel(string question, string rightAnswer, string[] questionSelection){
        mQuestion = question;
        mRightAnswer = rightAnswer;
        mQuestionSelection = questionSelection;
    }

    public string GetQuestion(){
        return mQuestion;
    }

    public string GetRightAnswer(){
        return mRightAnswer;
    }

    public string[] QuestionSelection(){
        return mQuestionSelection;
    }
}