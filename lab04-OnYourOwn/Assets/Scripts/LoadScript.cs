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

		originalFile = new FileInfo (Application.dataPath + "/testFile.txt");

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

		//tell teh reader to read a line of text, and store that in the line of TextVariable
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
		totalQuestions = answers.Count;
		NextQuestion ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void _TrueButtonClick()
	{
		CheckAnswer (true);
		NextQuestion ();
	}
	
	public void _FalseButtonClick()
	{
		CheckAnswer (false);
		NextQuestion ();
	}

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

	void NextQuestion()
	{
		if (questionNum <= questions.Count) {
			questionText.text = "Question " + questionNum + ": " + questions [questionNum - 1];
			correctNumberText.text = "Correct: " + totalRight;
			totalAnswersText.text = "Question " + questionNum + " of " + totalQuestions;
		} else
			DoneWithQuestions ();
	}

	void DoneWithQuestions()
	{
		questionText.text = "That's it!. How well did you do?";
		correctNumberText.text = "Correct: " + totalRight;
		totalAnswersText.text = "Question " + (questionNum - 1) + " of " + totalQuestions;
		
	}
}