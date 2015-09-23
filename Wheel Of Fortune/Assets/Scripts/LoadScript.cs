using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour 
{
    TextAsset textFile;
    TextReader reader;

    public List<string> sentences = new List<string>();
    public List<string> clues = new List<string>();

	// Use this for initialization
	void Start () 
    {
        textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
        reader = new StringReader(textFile.text);

        string lineOfText;
        int lineNumber = 0;

        while ((lineOfText = reader.ReadLine()) != null)
        {
            if (lineNumber % 2 == 0)
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
