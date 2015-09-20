using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: TriviaLoader 
/// </summary>
[RequireComponent(typeof(TriviaController))]
public class TriviaLoader : MonoBehaviour {
    #region Fields

    //modded file
    FileInfo triviaFile;

    //defaults
    TextAsset embedded;
    TextReader reader;

    public List<Trivia> triviaQuestions = new List<Trivia>(); 
    
    #endregion

    void Start() {
        triviaFile = new FileInfo(Application.dataPath + "/trivia.txt");

        if (triviaFile != null && triviaFile.Exists) {
            reader = triviaFile.OpenText();
        } else {
            embedded = (TextAsset) Resources.Load("trivia_embedded", typeof (TextAsset));
            reader = new StringReader(embedded.text);
        }

        string lineOfText = "";
        int lineNumber = 0;

        while ( ( lineOfText = reader.ReadLine() ) != null ) {

            string question = lineOfText;
            int answerCount = Convert.ToInt16(reader.ReadLine());
            List<string> answers = new List<string>();
            for (int i = 0; i < answerCount; i++) {
                answers.Add(reader.ReadLine());
            }

            Trivia temp = new Trivia(question, answerCount, answers);

            triviaQuestions.Add(temp);
            lineNumber++;
        }

        SendMessage( "BeginGame" );
    }

}

[Serializable]
public struct Trivia {

    public string question;
    public int answerCount;
    public List<string> answers;

    public Trivia(string question, int answerCount, List<string> answersList ) {
        this.question = question;
        this.answerCount = answerCount;
        answers = answersList;
    }

}