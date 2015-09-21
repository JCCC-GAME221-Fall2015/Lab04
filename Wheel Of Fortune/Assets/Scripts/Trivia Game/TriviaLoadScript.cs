using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[RequireComponent(typeof(TriviaReferences))]
public class TriviaLoadScript : MonoBehaviour {
	
	FileInfo originalFile;
	TextAsset textfile;
	TextReader reader;
	
	public List<string> questions = new List<string>();
	public List<string> answers = new List<string>();

	// Use this for initialization
	void Start () {
		
		originalFile = new FileInfo(Application.dataPath + "/questions.txt");
		
		if (originalFile != null && originalFile.Exists)
		{
			reader = originalFile.OpenText();
		}
		else
		{
			textfile = (TextAsset)Resources.Load("embedded2", typeof(TextAsset));
			reader = new StringReader(textfile.text);
		}
		
		string lineOfText;
		int lineNumber = 0;
		
		while ((lineOfText = reader.ReadLine()) != null)
		{
			if (lineNumber%5 == 0)
			{
				questions.Add(lineOfText);
			}
			else
			{
				answers.Add(lineOfText);
			}
			
			lineNumber++;
		}
		
		SendMessage("Gather");
	} // end method Start
} // end class TriviaLoadScript
