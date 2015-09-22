using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour
{
    private FileInfo originalFile;
	TextAsset textFile;
	TextReader reader;

	public List<string> phrases = new List<string>();
	public List<string> clues = new List<string>();

	// Use this for initialization
	void Start ()
	{
	    originalFile = new FileInfo(Application.dataPath + "/sentences.txt");

        // Check to see if original file is created for user input
	    if (originalFile != null && originalFile.Exists)
	    {
            // Original file exists, sets the reader to the original files text
	        reader = originalFile.OpenText();
	    }
	    else
	    {
            // Original file doesn't exist, sets the reader to the default text file
            textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
            reader = new StringReader(textFile.text);
        }

		string lineOfText;
		int lineNumber = 0;

		// Tell reader to read a line of text, and store it in the lineofText variable
		// Continue until there are no lines left
		while((lineOfText = reader.ReadLine()) != null)
		{
			if(lineNumber % 2 == 0)
			{
				// Even lines
				phrases.Add(lineOfText);
			}
			else
			{
				// Odd lines
				clues.Add (lineOfText);
			}

            // Increment the line number
			lineNumber++;
		}

        // Start the gather method
		SendMessage ("Gather");
	}
}
