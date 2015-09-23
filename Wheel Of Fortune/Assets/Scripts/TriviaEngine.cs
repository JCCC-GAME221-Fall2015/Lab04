/**
 * @author Darrick Hilburn
 * 
 * This script is the core engine for a trivia game.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(TriviaReferences))]
public class TriviaEngine : MonoBehaviour 
{
    const string CORRECT = "Correct!";
    const string WRONG = "Wrong!";
    const int NUM_ANSWERS = 4;

    TriviaReferences refs;
    int score; // Stores how many answers the player got right
    int question; // Stores which question the player is currently on

    // Begin sets the reference to the references script
    void Begin()
    {
        refs = gameObject.GetComponent<TriviaReferences>();
        StartGame();
    }

    // Start game initializes the game scene
    public void StartGame()
    {
        // Set up initial score and first question
        score = 0;
        question = 1;

        // Make sure buttons look unselected
        foreach (Button answer in refs.answerButtons)
            answer.targetGraphic.color = Color.white;

        // Hide end game info
        refs.gameEndScreen.enabled = false;
        foreach (Text text in refs.gameOverText)
            text.enabled = false;
        refs.resetButton.SetActive(false);
        refs.endGameButton.SetActive(false);

        LoadQuestion();
    }

    // LoadQuestion gets the data for the current question and
    //    puts it in the corresponding locations within the scene.
    public void LoadQuestion()
    {
        // Make sure answer buttons are enabled
        foreach (Button answer in refs.answerButtons)
            answer.enabled = true;
        // Clear response text field
        refs.response.text = "";
        // Deactivate the next question button
        refs.next.SetActive(false);
        // Update question and score
        refs.questionNumber.text = question + "/" + refs.numQuestions;
        refs.currentScore.text = score + "/" + refs.numQuestions;
        // Place the question on screen
        refs.question.text = refs.questions[question-1];
        // Set the answers in the answer buttons
        for (int i = 0; i < NUM_ANSWERS; i++)
            refs.answerButtonTexts[i].text = refs.answers[question - 1, i];
    }

    // CheckSelection compares the answer the user has selected to
    //    the correct answer and determines if the user is correct.
    public void CheckSelection(string selected)
    {
        // Assume user is initially incorrect
        bool correctAnswer = false;
        // Find the button with the selected text in it.
        string check = GameObject.Find(selected).GetComponentInChildren<Text>().text;

        // Compare the selected text to the correct text. If correct,
        //    Set correct to true
        if (check == refs.correct[question - 1])
            correctAnswer = true;

        // Check if the user is correct
        if (correctAnswer)
        {
            // Increment and update score
            score++;
            refs.currentScore.text = score + "/" + refs.numQuestions;
            // Tell the user they were correct
            refs.response.color = Color.green;
            refs.response.text = CORRECT;
        }
        else
        {
            // Color the user's answer red
            GameObject.Find(selected).GetComponent<Button>().targetGraphic.color = Color.red;
            // Tell the user they were incorrect
            refs.response.color = Color.red;
            refs.response.text = WRONG;
        }
        // Find the correct answer and color it green
        foreach (Text answerText in refs.answerButtonTexts)
            if (answerText.text == refs.correct[question - 1])
                answerText.GetComponentInParent<Button>().targetGraphic.color = Color.green;
        // Disable all the answer buttons
        foreach (Button answer in refs.answerButtons)
            answer.enabled = false;
        // Enable the next question button
        refs.next.SetActive(true);

    }

    // NextQuestion is called when the user clicks the button to move to the
    //    next question
    public void NextQuestion()
    {
        // Increment questions
        question++;
        // Check if we've completed the last question.
        //    If we have, call the EndGame function.
        if (question > refs.numQuestions)
            EndGame();
        else
        {
            // Re-enable all answer buttons and color them unselected
            foreach (Button button in refs.answerButtons)
            {
                button.enabled = true;
                button.targetGraphic.color = Color.white;
            }
            // Disable the next question button
            refs.next.SetActive(false);
            // Load in the next question
            LoadQuestion();
        }
    }

    // EndGame handles the game over screen.
    public void EndGame()
    {
        // Show the game over screen
        refs.gameEndScreen.enabled = true;
        // Show all text on the game over screen
        foreach (Text text in refs.gameOverText)
            text.enabled = true;
        // Show the user's final score
        refs.finalScore.text = score + "/" + refs.numQuestions;
        // Enable both the reset and exit game buttons
        refs.resetButton.SetActive(true);
        refs.endGameButton.SetActive(true);
    }

    // ExitGame closes the game.
    public void ExitGame()
    {
        Application.Quit();
    }
}
