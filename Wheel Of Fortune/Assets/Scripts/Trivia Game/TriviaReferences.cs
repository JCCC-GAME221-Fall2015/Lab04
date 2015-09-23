using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TriviaReferences : MonoBehaviour {
	
	//Variables to store all information, hidden from designer
	[HideInInspector]
	public List<string> questions = new List<string>();
	[HideInInspector]
	public List<string> answers = new List<string>();
	[HideInInspector]
	public string[] questionArray;
	[HideInInspector]
	public string[] correctAnswers;
	[HideInInspector]
	public string[] wrongAnswers1;
	[HideInInspector]
	public string[] wrongAnswers2;
	[HideInInspector]
	public string[] wrongAnswers3;

	void Gather () {
		int numQuestions = 0; // number of questions in input file
		int answerCounter = 0; // counter for current element in answers list

		questions = GetComponent<TriviaLoadScript>().questions;
		answers = GetComponent<TriviaLoadScript>().answers;

		numQuestions = questions.Count;
		questionArray = new string[numQuestions];
		correctAnswers = new string[numQuestions];
		wrongAnswers1 = new string[numQuestions];
		wrongAnswers2 = new string[numQuestions];
		wrongAnswers3 = new string[numQuestions];

		for (int i = 0; i < numQuestions; i++)
		{
			questionArray[i] = questions[i];
			correctAnswers[i] = answers[answerCounter];
			answerCounter++;
			wrongAnswers1[i] = answers[answerCounter];
			answerCounter++;
			wrongAnswers2[i] = answers[answerCounter];
			answerCounter++;
			wrongAnswers3[i] = answers[answerCounter];
			answerCounter++;
		}

		TriviaGameHelperScript.SetCorrectCount(0);
		TriviaGameHelperScript.SetWrongCount(0);

		//Inform the Engine to begin the game!
		SendMessage("Begin");
	} // end method Gather
} // end class TriviaReferences
