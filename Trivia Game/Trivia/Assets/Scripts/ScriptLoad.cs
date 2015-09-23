using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ScriptLoad : MonoBehaviour
{

	private FileInfo originalFile;
	private TextAsset textFile;
	private TextReader reader;

	// List to hold the questions and different choices
	public List<string> questions = new List<string>();
	public List<string> choice1 = new List<string>();
	public List<string> choice2 = new List<string>();
	public List<string> choice3 = new List<string>();
	public List<string> choice4 = new List<string>();  

	// Use this for initialization
	void Start ()
	{
		originalFile = new FileInfo(Application.dataPath + "/trivia.txt");

		// See if original file is created
		if (originalFile != null && originalFile.Exists)
		{
			// Set reader to that file
			reader = originalFile.OpenText();
		}
		else
		{
			// Original file doesn't exist, sets the reader to default text file
			textFile = (TextAsset) Resources.Load("embedded", typeof (TextAsset));
			reader = new StringReader(textFile.text);
		}

		// Holds a string
		string textLine;

		// var to hold the current line number
		int lineNum = 0;

		while ((textLine = reader.ReadLine()) != null)
		{
			if (lineNum % 5 == 0)
			{
				//Line number is on a question
				questions.Add(textLine);

			}
			else if (lineNum%5 == 1)
			{
				// Line number is on answer
				choice1.Add(textLine);
				
			}
			else if (lineNum % 5 == 2)
			{
				// Line number is on choice 2
				choice2.Add(textLine);

			}
			else if (lineNum % 5 == 3)
			{
				// Line number is on choice 3
				choice3.Add(textLine);

			}
			else if (lineNum % 5 == 4)
			{
				// Line number is on choice 4
				choice4.Add(textLine);

			}

			// increment the line number
			lineNum++;
		}

		// Start the gather method
		SendMessage("Gather");
	}

}
