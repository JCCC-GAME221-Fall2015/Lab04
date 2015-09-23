using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ScriptLoad : MonoBehaviour {

    TextAsset textFile;
    TextReader reader;

    void Start()
    {
        textFile = (TextAsset)Resources.Load("embedded", typeof(TextAsset));
        reader = new StringReader(textFile.text);

        string lineOfText;
        int lineNumber = 0;
    }
}
