/**
 * @author Darrick Hilburn
 * 
 * THis script holds data used for a trivia game and acts as a 
 * bridge between loading trivia data and utilizing the loaded data.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TriviaReferences : MonoBehaviour 
{
    const int NUM_ANSWERS = 4;

    // Number of questions 
    public int numQuestions; 
    // Array of questions
    public string[] questions; 
    // Array of arrays of answers to questions
    public string[,] answers; 
    // Array of correct answers to questions
    public string[] correct;
    // Question as text on screen
    public Text question; 
    // Container for the four on-screen answer buttons
    public Button[] answerButtons;

    public Text[] answerButtonTexts;
    // Text indicating if the user's answer is right or wrong
    public Text response; 
    // Button that lets the user go to the next question
    public GameObject next;
    // Text field for what question the user is on
    public Text questionNumber; 
    // Text field for the user's current score
    public Text currentScore; 
    // Image containing all endgame info
    public Image gameEndScreen; 
    // Contains all text on the Game Over screen
    public Text[] gameOverText;
    // Text on endgame image for user's final score
    public Text finalScore; 
    // Button on endgame image to reset the game
    public GameObject resetButton;

    public GameObject endGameButton;
       
	void Gather() 
    {
        numQuestions = TriviaLoadScript.GetNumberOfQuestion();
        questions = TriviaLoadScript.GetQuestions();
        answers = TriviaLoadScript.GetAnswers();
        correct = TriviaLoadScript.GetCorrectAnswers();
        // Gather question location
        question = GameObject.Find("Question").GetComponent<Text>();
        // Gather answer locations and contents
        answerButtons = GameObject.Find("Buttons").GetComponentsInChildren<Button>();
        answerButtonTexts = GameObject.Find("Buttons").GetComponentsInChildren<Text>();
        // Gather response location
        response = GameObject.Find("Response").GetComponent<Text>();
        // Gather next button location
        next = GameObject.Find("btn_Next");
        // Gather counter locations
        questionNumber = GameObject.Find("QuestionsCount").GetComponent<Text>();
        currentScore = GameObject.Find("ScoreCount").GetComponent<Text>();
        // Gather endgame info
        gameEndScreen = GameObject.Find("GameOver").GetComponent<Image>();
        gameOverText = GameObject.Find("GameOver").GetComponentsInChildren<Text>();
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        resetButton = GameObject.Find("RestartButton");
        endGameButton = GameObject.Find("EndGame");
   
        SendMessage("Begin");
	}
}

