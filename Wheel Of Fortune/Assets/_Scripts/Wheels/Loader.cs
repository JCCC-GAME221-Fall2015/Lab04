using UnityEngine;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Loader 
/// </summary>
[RequireComponent(typeof (References))]
public class Loader : MonoBehaviour {
    #region Fields

    FileInfo original;
    TextAsset textFile;
    TextReader reader;

    public List<string> sentences = new List<string>();
    public List<string> clues = new List<string>();

    #endregion

    void Start() {
        original = new FileInfo(Application.dataPath + "/test.txt");

        if (original != null && original.Exists) {
            reader = original.OpenText();
        } else {
            textFile = (TextAsset) Resources.Load("embedded", typeof (TextAsset));
            reader = new StringReader( textFile.text );
        }

        string lineOfText = "";
        int lineNumber = 0;

        while ((lineOfText = reader.ReadLine()) != null) {
            if (lineNumber % 2 == 0) { //even lines    
                sentences.Add(lineOfText);
            } else { //odd lines      
                clues.Add(lineOfText);
            }
            lineNumber++;
        }
        SendMessage("Gather");
    }
    
}