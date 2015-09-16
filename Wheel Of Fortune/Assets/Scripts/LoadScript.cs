using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour 
{
	TextAsset textFile;
	TextReader reader;

	public List<string> phrases = new List<string>();
	public List<string> clues = new List<string>();
	// Use this for initialization
	void Start () 
	{
		textFile = (TextAsset)Resources.Load ("embedded", typeof(TextAsset));
		reader = new StringReader (textFile.text);

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

			lineNumber++;
		}

		SendMessage ("Gather");
	}
}
