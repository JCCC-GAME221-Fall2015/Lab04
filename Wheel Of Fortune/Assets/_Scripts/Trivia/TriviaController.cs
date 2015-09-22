using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Controller 
/// </summary>
public class TriviaController : MonoBehaviour {
    #region Fields

    [Tooltip("text object to display questions")]
    public Text questionText;
    [Tooltip("text object to display game status")]
    public Text progressText; //wins, loses, total

    [Tooltip("gmae buttons. You need four")]
    public GameObject[] buttons;

    int right, wrong, total, currentQuestion, maxQuestions;

    public List<Trivia> triviaQuestions = new List<Trivia>();
   
    #endregion

    

    public void Play(GameObject thisButton) {
        string thisAnswer = thisButton.transform.GetChild(0).GetComponent<Text>().text;
        if (thisAnswer == triviaQuestions[currentQuestion].answers[0]) {
            //correct
            right++;
            total++;

            //still questions
            if (currentQuestion < maxQuestions - 1) {
                currentQuestion++;
                Setup();
            }
        } else {
            wrong++;
            total++;
            //still questions
            if ( currentQuestion < maxQuestions - 1 ) {
                currentQuestion++;
                Setup();
            }
        }

        //last question
        questionText.text = "You Finished the game! \n" +
                            string.Format( "Right: {0} | Wrong: {1} | Total: {2}   ", right, wrong, total );
        
        //disable all buttons
        foreach ( GameObject button in buttons ) {
            button.SetActive( false );
        }

    }

    void Setup() {
        //load in current trivia
        //display question
        //randomize buttons
        //disable buttons that arent active
        if (currentQuestion <= maxQuestions) {
            questionText.text = triviaQuestions[currentQuestion].question;

            //disable all buttons
            foreach (GameObject button in buttons) {
                button.SetActive(false);
            }

            //activate needed buttons
            for (int i = 0; i < triviaQuestions[currentQuestion].answerCount; i++) {
                buttons[i].SetActive(true);
                buttons[i].transform.GetChild(0).GetComponent<Text>().text = triviaQuestions[currentQuestion].answers[i];
            }

            //randomize which answer goes where

            


        }
    }

    void Update() {
        UpdateStatus();
    }

    void BeginGame() {
        triviaQuestions = GetComponent<TriviaLoader>().triviaQuestions;
        currentQuestion = 0;
        maxQuestions = triviaQuestions.Count;
        Setup();
    }

    void UpdateStatus() {
        progressText.text = string.Format("Right: {0} | Wrong: {1} | Total: {2}   ",right, wrong, total);
    }
}