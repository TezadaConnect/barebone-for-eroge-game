using Godot;
using System;

public partial class ResultScreenSceneController : Node{
	private const string NEXT_SCENE = "res://src/resources/screen_scenes/main_screen_scene.tscn";
	private Button mButton;
	private Label mResultLabel;
	private GameManager mGameManager;

	public override void _Ready() {
		mGameManager = GameManager.GetInstance();
		InitUiBindings();
		InitUiDisplay();
		InitButtonListeners();
	}

	private void InitUiBindings(){
		mResultLabel = GetNode<Label>("ResultStatus");
		mButton = GetNode<Button>("NextButton");
	}

	private void InitButtonListeners(){
		mButton.Connect("pressed", new Callable(this, "OnPressedButton"));
	}

	private void InitUiDisplay(){
		bool isCorrectAnswer = mGameManager.GetCurrentAnswer() == mGameManager.GetQuestionModel().GetRightAnswer(); 

		if(isCorrectAnswer) {
			mGameManager.SetScore(mGameManager.GetScore() + 1);
			mResultLabel.Text = "You're Correct, your score " + mGameManager.GetScore();
		}

		if(!isCorrectAnswer){
			mResultLabel.Text = "You're Wrong, the correct is " + mGameManager.GetQuestionModel().GetRightAnswer();
		}
		
		if(mGameManager.GetQuestionNumber() == QuestionsCollection.QuestionCount() - 1){
			mButton.Text = "Restart Game";
		}
	}

	private void OnPressedButton(){
		int questionNumber = mGameManager.GetQuestionNumber() + 1;
		if(questionNumber > QuestionsCollection.QuestionCount() - 1){
			questionNumber = 0;
			mGameManager.SetScore(0);
		}
		mGameManager.SetQuestionNumber(questionNumber);
		mGameManager.SetQuestionModelByQuestionNumber();
		GetTree().ChangeSceneToFile(NEXT_SCENE);
	}
}
