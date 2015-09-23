using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(ReferancesScript))]
public class EngineScript : MonoBehaviour 
{
    ReferancesScript referece;

    void Begin()
    { 
        referece = GetComponent<ReferancesScript>();


    }

    void TestAnswer(string answer)
    {
        GameObject.Find(answer).GetComponent<Button>().interactable = false;
        bool correct = false;

        if(GetComponent<LoadScript>().answers[3].ToUpper() == "T")
        {
            correct = true;
            return;
        }
    }
}
