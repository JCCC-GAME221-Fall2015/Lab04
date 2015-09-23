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

	// Use this for initialization
	void Start () {

		originalFile = new FileInfo (Application.dataPath + "/sentences.txt");

		if (originalFile != null && originalFile.Exists) 
		{
			reader = originalFile.OpenText ();
		} 
		else 
		{
			textFile = (TextAsset)Resources.Load ("embedded", typeof(TextAsset));
			reader = new StringReader (textFile.text);
		}

		string lineOfText;
		int lineNumber = 0;

		//tell teh reader to read a line of text, and store that in the line of TextVariable
		//continue doing this until there are no lines left
		while ((lineOfText = reader.ReadLine ()) != null) 
		{
			if(lineNumber%2 == 0)
			{
				sentences.Add (lineOfText);
			}
			else
			{
				clues.Add (lineOfText);
			}
			lineNumber++;
		}

		SendMessage ("Gather");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
