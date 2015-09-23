using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour {

	FileInfo originalFile;
	TextAsset textFile;
	TextReader reader;

	public List<string> questions = new List<string>();
	public List<string> answers = new List<string>();

	int questionNum = 1;
	int totalQuestions;
	int totalRight = 0;
	public Text questionText;
	public Text correctNumberText;
	public Text totalAnswersText;

	// Use this for initialization
	void Start () {
        //set the FileInfo to the UGC file
		originalFile = new FileInfo (Application.dataPath + "/testFile.txt");
        //if the file exists and is populated, use otherwise, fall back on the embedded file
		if (originalFile != null && originalFile.Exists) 
		{
			reader = originalFile.OpenText ();
		} 
		else 
		{
			textFile = (TextAsset)Resources.Load ("embedded", typeof(TextAsset));
			reader = new StringReader (textFile.text);
		}

		string lineOfText;
		int lineNumber = 0;

		//tell the reader to read a line of text, and store that in the line of TextVariable
		//continue doing this until there are no lines left
		while ((lineOfText = reader.ReadLine ()) != null) 
		{
			if(lineNumber%2 == 0)
			{
				questions.Add (lineOfText);
			}
			else
			{
				answers.Add (lineOfText);
			}
			lineNumber++;
		}
        //store total count of questions for use in showing data on screen
		totalQuestions = answers.Count;
		NextQuestion ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Checks if True is the correct answer and populates screen with info on next question
	public void _TrueButtonClick()
	{
		CheckAnswer (true);
		NextQuestion ();
	}
    //Checks if False is the correct answer and populates screen with info on next question
	public void _FalseButtonClick()
	{
		CheckAnswer (false);
		NextQuestion ();
	}

    //if not all questions have been answered, check if the current question's correct answer
    //matches the boolean value of the chosen answer. Then increments the quesiton total.
	void CheckAnswer(bool state)
	{
		if (questionNum <= questions.Count) {
			int checkAns = System.Convert.ToInt32 (answers [questionNum - 1]);
			bool checkState;
			if (checkAns > 0)
				checkState = true;
			else
				checkState = false;

			if ((checkState) == state) {
				totalRight++;
			}
			questionNum++;
		}
	}
    //if not done with all the questions, print the next question on the screen and update the total 
    //and correct questions. Otherwise, call DoneWithQuestions
	void NextQuestion()
	{
		if (questionNum <= questions.Count) {
			questionText.text = "Question " + questionNum + ": " + questions [questionNum - 1];
			correctNumberText.text = "Correct: " + totalRight;
			totalAnswersText.text = "Question " + questionNum + " of " + totalQuestions;
		} else
			DoneWithQuestions ();
	}

    //Prints final information to the screen.
	void DoneWithQuestions()
	{
		questionText.text = "That's it!. How well did you do?";
		correctNumberText.text = "Correct: " + totalRight;
		totalAnswersText.text = "Question " + (questionNum - 1) + " of " + totalQuestions;
		
	}
}