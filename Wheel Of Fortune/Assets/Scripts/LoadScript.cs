using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour 
{
    public List<string> sentences = new List<string>();
    public List<string> clues = new List<string>();

    FileInfo originalFile;
    TextAsset textFile;
    TextReader reader;

    void Start()
    {
        originalFile = new FileInfo(Application.dataPath + "/sentences.txt");

        if (!originalFile.Equals(null) && originalFile.Exists)
        {
            reader = originalFile.OpenText();
        }
        else
        {
            textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
            reader = new StringReader(textFile.text);
        }

        string lineOfText;
        int lineNumber = 0;

        while((lineOfText = reader.ReadLine()) != null)
        {
            if(lineNumber % 2 == 0)
            {
                sentences.Add(lineOfText);
            }
            else
            {
                clues.Add(lineOfText);
            }
            lineNumber++;
        }
        SendMessage("Gather");
    }
}
