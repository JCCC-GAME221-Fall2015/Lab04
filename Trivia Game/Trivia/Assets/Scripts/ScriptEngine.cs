using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(ScriptReferences))]
public class ScriptEngine : MonoBehaviour
{
    // Vars
    private ScriptReferences refs;
    private int numRight;
    private int curQuestion;
    private int totalQuestons;

    private string correctAnswer = " ";

    void Begin()
    {
        // Link to references script
        refs = gameObject.GetComponent<ScriptReferences>();

        // Starts game
        StartGame();
    }

    public void StartGame()
    {
        // Sets current question and number right to 0
        numRight = 0;
        curQuestion = 0;

        // Number of questions
        totalQuestons = refs.questions.Count;
        // The correct answer
        correctAnswer = refs.choice1[curQuestion];

        // Randomize the answers for display
        RandomizeAnswers(curQuestion);


        refs.curQuestionText.GetComponent<Text>().text = string.Format("Question: {0}/{1}", curQuestion + 1, totalQuestons);

    }

    public void _BtnSelectAnswer(Text buttonText)
    {
        // Check that the buttons text is the correct answer
        if (buttonText.text == correctAnswer)
        {
            // If it is increment the number answered right
            numRight++;
        }
        // Checks to see if this was the last question
        if ((curQuestion + 1) == totalQuestons)
        {
            // If it was save the number of right answers and total questions to player prefs
            PlayerPrefs.SetInt("NumRight", numRight);
            PlayerPrefs.SetInt("TotalQuestions", totalQuestons);

            // Load the game over scene
            Application.LoadLevel("SceneGameOver");
            
        }
        else
        {
            // increment the curQuestion
            curQuestion++;

            // Set the new correct answer
            correctAnswer = refs.choice1[curQuestion];

            // Randomize the answer options
            RandomizeAnswers(curQuestion);

            // Set the cur question text
            refs.curQuestionText.GetComponent<Text>().text = string.Format("Question: {0}/{1}", curQuestion + 1, totalQuestons);
        }
    }
    
    void RandomizeAnswers(int cur)
    {

        // Question will be same position, doesn't need to be randomized
        refs.questionText.GetComponent<Text>().text = refs.questions[cur];

        // Randomly switch between 5 different options for randomizing the answers
        switch ((int)Random.Range(1, 6))
        {
            case 1:
                refs.answer1.GetComponentInChildren<Text>().text = refs.choice1[cur];
                refs.answer2.GetComponentInChildren<Text>().text = refs.choice2[cur];
                refs.answer3.GetComponentInChildren<Text>().text = refs.choice3[cur];
                refs.answer4.GetComponentInChildren<Text>().text = refs.choice4[cur];
                break;
            case 2:
                refs.answer4.GetComponentInChildren<Text>().text = refs.choice1[cur];
                refs.answer3.GetComponentInChildren<Text>().text = refs.choice2[cur];
                refs.answer2.GetComponentInChildren<Text>().text = refs.choice3[cur];
                refs.answer1.GetComponentInChildren<Text>().text = refs.choice4[cur];
                break;
            case 3:
                refs.answer3.GetComponentInChildren<Text>().text = refs.choice1[cur];
                refs.answer1.GetComponentInChildren<Text>().text = refs.choice2[cur];
                refs.answer4.GetComponentInChildren<Text>().text = refs.choice3[cur];
                refs.answer2.GetComponentInChildren<Text>().text = refs.choice4[cur];
                break;
            case 4:
                refs.answer1.GetComponentInChildren<Text>().text = refs.choice1[cur];
                refs.answer3.GetComponentInChildren<Text>().text = refs.choice2[cur];
                refs.answer2.GetComponentInChildren<Text>().text = refs.choice3[cur];
                refs.answer4.GetComponentInChildren<Text>().text = refs.choice4[cur];
                break;
            case 5:
                refs.answer4.GetComponentInChildren<Text>().text = refs.choice1[cur];
                refs.answer1.GetComponentInChildren<Text>().text = refs.choice2[cur];
                refs.answer2.GetComponentInChildren<Text>().text = refs.choice3[cur];
                refs.answer3.GetComponentInChildren<Text>().text = refs.choice4[cur];
                break;
        }
    }
}
