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

    public void Play() {
        //load in current trivia
        //display question
        //randomize buttons
        //disable buttons that arent active
        questionText.text = triviaQuestions[currentQuestion].question;
        //disable all buttons
        foreach (GameObject button in buttons) {
            button.SetActive(false);
        }

        for (int i = 0; i < triviaQuestions[currentQuestion].answerCount; i++) {
            buttons[i].SetActive(true);
        }



    }

    void Update() {
        UpdateStatus();
    }

    void BeginGame() {
        triviaQuestions = GetComponent<TriviaLoader>().triviaQuestions;
        currentQuestion = 0;
        maxQuestions = triviaQuestions.Count;
        Play();
    }

    void UpdateStatus() {
        progressText.text = string.Format("Right: {0} | Wrong: {1} | Total: {2}   ",right, wrong, total);
    }
}