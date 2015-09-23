using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class ScriptTriviaEngine : MonoBehaviour {

    public Text questionText;
    public Text stats;
    public Text feedback;
    List<bool> questionAnswers = new List<bool>(0);
    List<string> questions = new List<string>(0);
    bool currentAnswer;
    int numCorrect = 0;
    int totalQuestions;
    bool gameOver = false;

	void Start ()
    {
        StreamReader reader;
        string currentLine;
        FileInfo questionsFile = new FileInfo(Application.dataPath + "/questions.txt");
        if (questionsFile.Exists && questionsFile != null)
        {
            reader = new StreamReader(Application.dataPath + "/questions.txt");
            while ((currentLine = reader.ReadLine()) != null)
            {
                questions.Add(currentLine);
                currentLine = reader.ReadLine();
                if (currentLine.ToUpper() == "TRUE")
                {
                    questionAnswers.Add(true);
                }
                else if (currentLine.ToUpper() == "FALSE")
                {
                    questionAnswers.Add(false);
                }
                else
                {
                    questions.RemoveAt(questions.Count - 1);
                    break;
                }
            }
        }
        TextAsset embededQuestions = (TextAsset)Resources.Load("questions", typeof(TextAsset));
        StringReader embedReader = new StringReader(embededQuestions.text);
        while ((currentLine = embedReader.ReadLine()) != null)
        {
            questions.Add(currentLine);
            currentLine = embedReader.ReadLine();
            if (currentLine.ToUpper() == "TRUE")
            {
                questionAnswers.Add(true);
            }
            else if (currentLine.ToUpper() == "FALSE")
            {
                questionAnswers.Add(false);
            }
            else
            {
                questions.RemoveAt(questions.Count - 1);
                break;
            }
        }
        totalQuestions = questions.Count;
        RefreshQuestion();
	}
	
	void RefreshQuestion ()
    {
        if (questions.Count == 0)
        {
            questionText.text = "Game Completed! Congratulations! Click any button to quit.";
            gameOver = true;
        }
        else
        {
            //Pick a random question, display it, and remove it from the lists
            int index = Random.Range(0, questions.Count);
            questionText.text = questions[index];
            currentAnswer = questionAnswers[index];
            questions.RemoveAt(index);
            questionAnswers.RemoveAt(index);
        }
        //Update stats
        stats.text = "Correct: " + numCorrect + "/" + totalQuestions + "   Answered: "
            + (totalQuestions - (gameOver ? 0 : 1) - questions.Count) + "/" + totalQuestions;

	}

    public void _TrueButton()
    {
        if (gameOver)
        {
            Application.Quit();
        }
        else
        {
            feedback.text = "That one was False, Sorry!";
            if (currentAnswer)
            {
                numCorrect++;
                feedback.text = "Correct!";
            }
            RefreshQuestion();
        }
    }

    public void _FalseButton()
    {
        if (gameOver)
        {
            Application.Quit();
        }
        else
        {
            feedback.text = "That one was True, Sorry!";
            if (!currentAnswer)
            {
                numCorrect++;
                feedback.text = "Correct!";
            }
            RefreshQuestion();
        }
    }
}
