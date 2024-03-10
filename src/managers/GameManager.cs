
class GameManager {
    private int mScore;
    private int mQuestionNumber;
    private string mCurrentAnswer;
    private QuestionModel mQuestionModel;

    private static GameManager mGameManagerInstance;

    public GameManager(){
        mScore = 0;
        mQuestionNumber = 0;
        mQuestionModel = QuestionsCollection.GetQuestionByQuestionNumber(mQuestionNumber);
    }

    public static GameManager GetInstance(){
        if(mGameManagerInstance == null){
            mGameManagerInstance = new GameManager();
        }
        return mGameManagerInstance;
    }

    public int GetScore(){
        return mScore;
    }

    public int GetQuestionNumber(){
        return mQuestionNumber;
    }

    public QuestionModel GetQuestionModel(){
        return mQuestionModel;
    }

    public string GetCurrentAnswer(){
        return mCurrentAnswer;
    }

    public void SetScore(int value){
        mScore = value;
    }

    public void SetQuestionNumber(int value){
        mQuestionNumber = value;
    }

    public void SetCurrentAnswer(string answer){
        mCurrentAnswer = answer;
    }

    public void SetQuestionModelByQuestionNumber(){
        mQuestionModel = QuestionsCollection.GetQuestionByQuestionNumber(mQuestionNumber);
    }
}