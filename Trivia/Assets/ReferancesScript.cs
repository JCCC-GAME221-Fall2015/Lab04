using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ReferancesScript : MonoBehaviour 
{
    public Text questionText;
    public Text aText, bText, cText, dText;
    [HideInInspector]
    public static bool isCorrect = false;

	// Use this for initialization
	void Start () 
    {
        questionText.text = GetComponent<LoadScript>().questions[0] + "?";

        aText.text = GetComponent<LoadScript>().answers[0];
        bText.text = GetComponent<LoadScript>().answers[1];
        cText.text = GetComponent<LoadScript>().answers[2];
        dText.text = GetComponent<LoadScript>().answers[3];
	}
}
