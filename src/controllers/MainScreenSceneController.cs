using Godot;
using System;

public partial class MainScreenSceneController : Node {
	private Label questionLabel;
	private Label scoreLabel;
	private Button buttonA;
	private Button buttonB;
	private Button buttonC;
	private Button buttonD;
	
	private const string NEXT_SCENE = "res://src/resources/screen_scenes/result_screen_scene.tscn";

	private GameManager mGameManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		mGameManager = GameManager.GetInstance();
		InitUIBindings();
		InitButtonListeners();
		InitUIDisplay();
	}

	private void InitUIBindings(){
		questionLabel = GetNode<Label>("QuestionLabel");
		scoreLabel = GetNode<Label>("ScoreLabel");
		buttonA = GetNode<Button>("SelectionButtonA");
		buttonB = GetNode<Button>("SelectionButtonB");
		buttonC = GetNode<Button>("SelectionButtonC");
		buttonD = GetNode<Button>("SelectionButtonD");
	}

	private void InitButtonListeners(){
		buttonA.Connect("pressed", new Callable(this, "OnPressedA"));
		buttonB.Connect("pressed", new Callable(this, "OnPressedB"));
		buttonC.Connect("pressed", new Callable(this, "OnPressedC"));
		buttonD.Connect("pressed", new Callable(this, "OnPressedD"));
	}

	private void InitUIDisplay(){
		questionLabel.Text = mGameManager.GetQuestionModel().GetQuestion();
		scoreLabel.Text = "Score: " + mGameManager.GetScore();
		buttonA.Text = mGameManager.GetQuestionModel().QuestionSelection()[0];
		buttonB.Text = mGameManager.GetQuestionModel().QuestionSelection()[1];
		buttonC.Text = mGameManager.GetQuestionModel().QuestionSelection()[2];
		buttonD.Text = mGameManager.GetQuestionModel().QuestionSelection()[3];
	}

	private void OnPressedA() => SetAnswerAndMoveToResultScreen(buttonA);

	private void OnPressedB() => SetAnswerAndMoveToResultScreen(buttonB);

	private void OnPressedC() => SetAnswerAndMoveToResultScreen(buttonC);

	private void OnPressedD() => SetAnswerAndMoveToResultScreen(buttonD);

	private void SetAnswerAndMoveToResultScreen(Button button){
		mGameManager.SetCurrentAnswer(button.Text);
		GetTree().ChangeSceneToFile(NEXT_SCENE);
	}
}
