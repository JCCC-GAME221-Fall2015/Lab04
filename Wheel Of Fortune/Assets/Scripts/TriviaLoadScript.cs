/**
 * @author Darrick Hilburn
 * 
 * THis script is used for loading in data for a trivia game.
 */

using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

// enum used for loading in question data.
enum ReadLineType
{
    QUESTION,
    ANSWERS,
    CORRECT
}

[RequireComponent(typeof(TriviaReferences))]
public class TriviaLoadScript : MonoBehaviour
{
    #region Constants
    const int NUM_ANSWERS = 4; // How many answers will be on screen
    const int READIN_LINES = 3; // Lines between different pieces of data
    #endregion

    #region Vars
   static int numQuestions; // Number of questions in a game
    
    static string[] loadQuestions; // Array to hold questions
    static string[,] loadAnswers; // Array of string arrays to hold answers per question
    static string[] loadCorrect; // Array to hold which answer is correct per question

    List<string> questionsList = new List<string>(); // List used for reading in question data
    public List<string> answersList = new List<string>(); // List used for reading in answer data
    List<string> correctList = new List<string>(); // List used for reading in correct answer data

    FileInfo originalFile; // Location of embedded data file
    TextAsset textFile; // text from user created data file
    TextReader reader; // Reader for reading text in a data file
    #endregion

	void Start ()
    {
        #region File Load
        // Read in file information
        originalFile = new FileInfo(Application.dataPath + "/trivia.txt");
        if (!originalFile.Equals(null) && originalFile.Exists)
            reader = originalFile.OpenText();
        else
        {
            textFile = (TextAsset)Resources.Load("embeddedTrivia", typeof(TextAsset));
            reader = new StringReader(textFile.text);
        }

        #endregion

        #region File Read

        string lineOfText;
        int lineNumber = 0;

        // Determine where data should go based on 
        //    Which line was read in
        while ((lineOfText = reader.ReadLine()) != null)
        {
            int lineNumberCheck = lineNumber % READIN_LINES;
            switch (lineNumberCheck)
            {
                case((int)ReadLineType.QUESTION): // Question line
                    numQuestions++;
                    questionsList.Add(lineOfText);
                    break;
                case((int)ReadLineType.ANSWERS): // Answers line
                    answersList.Add(lineOfText);
                    break;
                case((int)ReadLineType.CORRECT): // Correct answers line
                    correctList.Add(lineOfText);
                    break;
                default:
                    break;
            }
            lineNumber++;
        }
        #endregion

        #region Data Initialization
        // Initialize array sizes
        loadQuestions = new string[numQuestions];
        loadAnswers = new string[numQuestions, NUM_ANSWERS];
        loadCorrect = new string[numQuestions];
        
        // Load read data into the arrays
        for (int i = 0; i < numQuestions; i++)
        {
            loadQuestions[i] = questionsList[i];
            loadCorrect[i] = correctList[i];
            // Split the answers list apart
            string[] separateAnswers = new string[NUM_ANSWERS];
            separateAnswers = answersList[i].Split(',');
            // Load the answers as string arrays within the answers string array
            for (int j = 0; j < NUM_ANSWERS; j++)
            {
                loadAnswers[i, j] = separateAnswers[j];
            }
        }
        #endregion

        SendMessage("Gather");
	}

    

    public static int GetNumberOfQuestion()
    {
        return numQuestions;
    }

    public static string[] GetQuestions()
    {
        return loadQuestions;
    }

    public static string[,] GetAnswers()
    {
        return loadAnswers;
    }

    public static string[] GetCorrectAnswers()
    {
        return loadCorrect;
    }
}