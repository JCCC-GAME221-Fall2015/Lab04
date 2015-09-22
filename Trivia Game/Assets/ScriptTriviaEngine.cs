using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class ScriptTriviaEngine : MonoBehaviour {

    public Text questionText;
    public Text stats;
    List<bool> questionAnswers = new List<bool>(0);
    List<string> questions = new List<string>(0);
    bool currentAnswer;
    int numCorrect = 0;
    int totalQuestions;
	void Start ()
    {
        StreamReader reader;
        string currentLine;
        FileInfo questionsFile = new FileInfo(Application.dataPath + "questions.txt");
        if (questionsFile.Exists)
        {
            reader = new StreamReader(Application.dataPath + "questions.txt");
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
        reader = new StreamReader(embededQuestions.text);
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
        totalQuestions = questions.Count;
        RefreshQuestion();
	}
	
	void RefreshQuestion ()
    {
        stats.text = numCorrect + "/" + totalQuestions;
        int index = Random.Range(0, questions.Count);
        questionText.text = questions[index];
        currentAnswer = questionAnswers[index];
        questions.RemoveAt(index);
        questionAnswers.RemoveAt(index);

	}
}
