using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Author: Andrew Seba
/// Description: Sets up the UI variables for the engine to input. and starts
/// the engine.
/// </summary>
public class References : MonoBehaviour {

    //public Text[] questions;
    public Text questionText;
    public Button[] buttons;

    public List<string> questions = new List<string>();
    public List<string> answers = new List<string>();

    public void Gather()
    {

        
        questions = GetComponent<LoadFile>().questions;
        answers = GetComponent<LoadFile>().answers;

        questionText = GameObject.Find("Text_Question").GetComponent<Text>();

        buttons = new Button[4];
        buttons[0] = GameObject.Find("Answer1").GetComponent<Button>();
        buttons[1] = GameObject.Find("Answer2").GetComponent<Button>();
        buttons[2] = GameObject.Find("Answer3").GetComponent<Button>();
        buttons[3] = GameObject.Find("Answer4").GetComponent<Button>();


        SendMessage("Begin");
    }
}
