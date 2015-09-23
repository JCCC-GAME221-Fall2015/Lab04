using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScriptReferences : MonoBehaviour
{

    // Variables
    [HideInInspector]
    public Text questionText, curQuestionText;

    [HideInInspector]
    public Button answer1, answer2, answer3, answer4;

    [HideInInspector]
    public List<string> questions = new List<string>();
    [HideInInspector]
    public List<string> choice1 = new List<string>();
    [HideInInspector]
    public List<string> choice2 = new List<string>();
    [HideInInspector]
    public List<string> choice3 = new List<string>();
    [HideInInspector]
    public List<string> choice4 = new List<string>();

    void Gather()
    {
        // Gets the lists from the load script
        questions = GetComponent<ScriptLoad>().questions;
        choice1 = GetComponent<ScriptLoad>().choice1;
        choice2 = GetComponent<ScriptLoad>().choice2;
        choice3 = GetComponent<ScriptLoad>().choice3;
        choice4 = GetComponent<ScriptLoad>().choice4;

        // Finds the text fields
        curQuestionText = GameObject.Find("TextCurrentQuestion").GetComponent<Text>();
        questionText = GameObject.Find("TextQuestion").GetComponent<Text>();

        // Finds the buttons
        answer1 = GameObject.Find("BtnAnswer1").GetComponent<Button>();
        answer2 = GameObject.Find("BtnAnswer2").GetComponent<Button>();
        answer3 = GameObject.Find("BtnAnswer3").GetComponent<Button>();
        answer4 = GameObject.Find("BtnAnswer4").GetComponent<Button>();

        // Starts the begin method
        SendMessage("Begin");
    }
}
