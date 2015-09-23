using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Author: Andrew Seba
/// Description: Loads the UI in game with information that user can interact
///     with, when an answer is selected it restarts the StartGame() method.
/// </summary>
[RequireComponent(typeof(References))]
public class Engine : MonoBehaviour {

    int numQuestion = 0;

    References refs;
    string quest = "How many shots go into a grande latte?";
    string[] answers = { "2", "1", "3", "4" };
    string correctAnswer;

    GameObject gamePanel;
    GameObject playAgainPanel;

    /// <summary>
    /// Controls what displays when there are no more questions.
    /// </summary>
    public void EndGame()
    {
        gamePanel.SetActive(false);
        playAgainPanel.SetActive(true);

    }

    /// <summary>
    /// initializes this script.
    /// </summary>
    void Begin()
    {
        refs = gameObject.GetComponent <References>();

        if (GameObject.Find("Panel_Game").gameObject != null)
        {
            gamePanel = GameObject.Find("Panel_Game").gameObject;
        }
        else
        {
            Debug.Log("Panel_Game is disabled in the heirarchy, Please re-Enable!");
        }


        if(GameObject.Find("Panel_PlayAgain").gameObject != null)
        {
            playAgainPanel = GameObject.Find("Panel_PlayAgain").gameObject;
        }
        else
        {
            Debug.Log("Panel_PlayAgain is disabled in the heirarchy, Please re-Enable!");
        }

        playAgainPanel.SetActive(false);
        gamePanel.SetActive(false);

    }

    /// <summary>
    /// Re-does the question and button fields with new answers
    ///     (Called by the start button on the main menu as well)
    /// </summary>
    public void StartGame()
    {

        int numSent = refs.questions.Count;
        int randomSent = Random.Range(0, numSent);

        quest = refs.questions[randomSent];
        



        //want to split the line of answers between commas.
        answers = refs.answers[randomSent].Split(',');

        //Get correct answer
        correctAnswer = answers[0];

        //Only display as many buttons as we need
        for(int i = 0; i < 4; i++)
        {
            if(i < answers.Length)
            {
                refs.buttons[i].gameObject.SetActive(true);

            }
            else
            {
                refs.buttons[i].gameObject.SetActive(false);
            }
            
        }

        
        List<string> tempAnswers = new List<string>(answers);
        List<string> randomAnswers = new List<string>();

        //randomize
        for (int i = answers.Length - 1; i >= 0; i--)
        {
            int randomNum = Random.Range(0, tempAnswers.Count);
            randomAnswers.Add(tempAnswers[randomNum]);
            tempAnswers.RemoveAt(randomNum);
        }

        //Assign the text in the UI
        for (int i = 0; i< answers.Length; i++)
        {
             refs.buttons[i].GetComponentInChildren<Text>().text = randomAnswers[i];
        }

        refs.questionText.text = quest;
        if (refs.questions.Count <= 1)
        {
            //call end game
            //EndGame();
            Application.Quit();
        }
        else
        {
            //Stops Duplicate Questions
            refs.questions.RemoveAt(randomSent);
            refs.answers.RemoveAt(randomSent);

        }

    }

    /// <summary>
    /// Checks to see if the text string in the button matches the correct
    ///     answer assigned within StartGame()
    /// </summary>
    /// <param name="pAnswer">Buttons are giving back numbers 0-3 in order of buttons</param>
    public void _CheckAnswer(int pAnswer)
    {
        if ((answers[0] == refs.buttons[pAnswer].GetComponentInChildren<Text>().text))
        {
            Debug.Log("YOU GOT IT!");
            
        }
        StartGame();
        numQuestion += 1;
    }
}
