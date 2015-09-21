using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TriviaReferences : MonoBehaviour 
{
    
    public int numQuestions;
    public string[] questions;
    public string[,] answers;
    public string[] correct;

	// Use this for initialization
	void Gather() 
    {
        numQuestions = GetComponent<TriviaLoadScript>().numQuestions;
        questions = GetComponent<TriviaLoadScript>().loadQuestions;
        answers = GetComponent<TriviaLoadScript>().loadAnswers;
        correct = GetComponent<TriviaLoadScript>().loadCorrect;

	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
