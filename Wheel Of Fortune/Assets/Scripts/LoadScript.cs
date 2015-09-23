using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour {

    FileInfo originalFile;
    TextAsset textFile;
    TextReader reader;

    public List<string> sentences = new List<string>();
    public List<string> clues = new List<string>();

    void Start()
    {

        originalFile = new FileInfo(Application.dataPath + "/sentences.txt");

        if(originalFile != null && originalFile.Exists)
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
            if(lineNumber %2 == 0)
            {
                //even lines
                sentences.Add(lineOfText);
            }
            else
            {
                //odd lines
                clues.Add(lineOfText);
            }

            lineNumber++;
        }

        SendMessage("Gather");
    }

    
}
