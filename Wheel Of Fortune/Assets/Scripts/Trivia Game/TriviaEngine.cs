using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Force unity to add the TriviaReferences script if it is not already on the object
[RequireComponent(typeof(TriviaReferences))]
public class TriviaEngine : MonoBehaviour {
	
	const int NUM_ANSWERS = 4; // number of answers per question
	
	TriviaReferences refs;
	private int questionCount = 0;
	private int rightCount = 0;
	private int wrongCount = 0;
	private int currentQuestion = 0;

//	private GameObject canvasObject;
	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;
	private Text button1Text;
	private Text button2Text;
	private Text button3Text;
	private Text button4Text;
	private Text questionText;
	private Text questionNumberText;
	private string outputString;
	private string[] questionArray;
	private string[] correctAnswers;
	private string[] wrongAnswers1;
	private string[] wrongAnswers2;
	private string[] wrongAnswers3;
	private int correctButton = 0; // number of button containing the correct answer
	private bool waitingForKey = false;

	void Begin()
	{
		//Gets a link to the TriviaReferences script
		refs = gameObject.GetComponent<TriviaReferences>();
//		canvasObject = GameObject.Find("Canvas");
		button1 = GameObject.Find("Answer1Button");
		button2 = GameObject.Find("Answer2Button");
		button3 = GameObject.Find("Answer3Button");
		button4 = GameObject.Find("Answer4Button");

		button1Text = button1.GetComponentInChildren<Text>();
		button2Text = button2.GetComponentInChildren<Text>();
		button3Text = button3.GetComponentInChildren<Text>();
		button4Text = button4.GetComponentInChildren<Text>();
		questionText = GameObject.Find("QuestionText").GetComponent<Text>();
		questionNumberText = GameObject.Find("QuestionNumber").GetComponent<Text>();

		questionArray = GetComponent<TriviaReferences>().questionArray;
		correctAnswers = GetComponent<TriviaReferences>().correctAnswers;
		wrongAnswers1 = GetComponent<TriviaReferences>().wrongAnswers1;
		wrongAnswers2 = GetComponent<TriviaReferences>().wrongAnswers2;
		wrongAnswers3 = GetComponent<TriviaReferences>().wrongAnswers3;
		questionCount = questionArray.Length;

		//Starts the game
		StartGame();
	}

	public void PressButton1()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			CheckButtonPress(1);
		}
	}
	
	public void PressButton2()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			CheckButtonPress(2);
		}
	}
	
	public void PressButton3()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			CheckButtonPress(3);
		}
	}
	
	public void PressButton4()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			CheckButtonPress(4);
		}
	}
	
	public void CheckButtonPress(int buttonNumber)
	{
		if (correctButton == buttonNumber)
			rightCount++;
		else
			wrongCount++;
		currentQuestion++;
		if (currentQuestion < questionCount)
		{
			correctButton = Random.Range(1, NUM_ANSWERS + 1);
			DisplayQuestionAndAnswers(correctButton, currentQuestion);
		}
		else
		{
			TriviaGameHelperScript.SetCorrectCount(rightCount);
			TriviaGameHelperScript.SetWrongCount(wrongCount);
			LoadGameOverScene();
		}
	} // end method CheckButtonPress

	private void DisplayQuestionAndAnswers(int correctButton, int questionNumber)
	{
		questionText.text = questionArray[questionNumber];
		switch (correctButton)
		{
			case 1:
				button1Text.text = correctAnswers[questionNumber];
				button2Text.text = wrongAnswers1[questionNumber];
				button3Text.text = wrongAnswers2[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			case 2:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = correctAnswers[questionNumber];
				button3Text.text = wrongAnswers2[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			case 3:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = wrongAnswers2[questionNumber];
				button3Text.text = correctAnswers[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			default:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = wrongAnswers2[questionNumber];
				button3Text.text = wrongAnswers3[questionNumber];
				button4Text.text = correctAnswers[questionNumber];
				break;
		}
		ShowQuestionNumber();
		waitingForKey = true;
	} // end method DisplayQuestionAndAnswers
	
	public void StartGame()
	{
		rightCount = 0;
		wrongCount = 0;
		currentQuestion = 0;
		correctButton = Random.Range(1, NUM_ANSWERS + 1);
		DisplayQuestionAndAnswers(correctButton, currentQuestion);
	} // end method StartGame
	
	private void ShowQuestionNumber()
	{
		outputString = "Question " + (currentQuestion + 1).ToString() + " / " + questionCount.ToString();
		questionNumberText.text = outputString;
	}
	
	private void LoadGameOverScene ()
	{
		Application.LoadLevel("GameOverScene");
	}
} // end class TriviaEngine
