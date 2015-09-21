using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[RequireComponent(typeof(References))]
public class LoadScript : MonoBehaviour {

	FileInfo originalFile;
	TextAsset textfile;
	TextReader reader;

	public List<string> sentences = new List<string>();
	public List<string> clues = new List<string>();

	
	// Use this for initialization
	void Start () {

		originalFile = new FileInfo(Application.dataPath + "/sentences.txt");

		if (originalFile != null && originalFile.Exists)
		{
			reader = originalFile.OpenText();
		}
		else
		{
			textfile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
			reader = new StringReader(textfile.text);
		}

		string lineOfText;
		int lineNumber = 0;

		while ((lineOfText = reader.ReadLine()) != null)
		{
			if (lineNumber%2 == 0)
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
