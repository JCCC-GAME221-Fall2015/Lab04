using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour 
{
    // Lists that hold sentences to solve and clues for sentences.
    public List<string> sentences = new List<string>();
    public List<string> clues = new List<string>();

    FileInfo originalFile;
    TextAsset textFile;
    TextReader reader;

    void Start()
    {
        originalFile = new FileInfo(Application.dataPath + "/sentences.txt");
        // Check if a user provided file exists
        // If file exists, read data from the file
        if (!originalFile.Equals(null) && originalFile.Exists)
        {
            reader = originalFile.OpenText();
        }
        // If file doesn't exist, read from the embedded game file
        else
        {
            textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
            reader = new StringReader(textFile.text);
        }

        string lineOfText;
        int lineNumber = 0;

        // Read from the reader file while there is still data in the file
        while((lineOfText = reader.ReadLine()) != null)
        {
            // Even line number: sentence
            if(lineNumber % 2 == 0)
            {
                sentences.Add(lineOfText);
            }
            // odd line number: clue
            else
            {
                clues.Add(lineOfText);
            }
            lineNumber++;
        }
        // Call Gather function
        SendMessage("Gather");
    }
}
