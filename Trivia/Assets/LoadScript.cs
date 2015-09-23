using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


[RequireComponent(typeof(ReferancesScript))]
public class LoadScript : MonoBehaviour
{
    TextAsset textFile;
    TextReader reader;

    public List<string> questions = new List<string>();
    public List<string> answers = new List<string>();

    // Use this for initialization
    void Start()
    {
        textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
        reader = new StringReader(textFile.text);

        string lineOfText;

        while ((lineOfText = reader.ReadLine()) != null)
        {
            string[] arg = lineOfText.Split('_');
            if (arg[0].ToUpper() == "Q")
            {
                questions.Add(arg[1]);
            }
            if (arg[0] == "A")
            {
                if (arg[1] == "A")
                {
                    answers.Add(arg[2]);
                    if (arg[3].ToUpper() == "T")
                    {
                        ReferancesScript.isCorrect = true;
                    }
                    else
                    {
                        ReferancesScript.isCorrect = false;
                    }
                }

                if (arg[1] == "B")
                {
                    answers.Add(arg[2]);
                    if (arg[3].ToUpper() == "T")
                    {
                        ReferancesScript.isCorrect = true;
                    }
                    else
                    {
                        ReferancesScript.isCorrect = false;
                    }
                }

                if (arg[1] == "C")
                {
                    answers.Add(arg[2]);
                    if (arg[3].ToUpper() == "T")
                    {
                        ReferancesScript.isCorrect = true;
                    }
                    else
                    {
                        ReferancesScript.isCorrect = false;
                    }
                }

                if (arg[1] == "D")
                {
                    answers.Add(arg[2]);
                    if (arg[3].ToUpper() == "T")
                    {
                        ReferancesScript.isCorrect = true;
                    }
                    else
                    {
                        ReferancesScript.isCorrect = false;
                    }
                }
            }
        }
    }
}