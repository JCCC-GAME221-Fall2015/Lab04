using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{

	private Text finalText;
	private int numRight;
	private int totalQuestions;

	// Use this for initialization
	void Start ()
	{
		// Finds the text field
		finalText = GameObject.Find("Text").GetComponent<Text>();

		// Gets the number of questions and number answered correctly from player prefs
		numRight = PlayerPrefs.GetInt("NumRight");
		totalQuestions = PlayerPrefs.GetInt("TotalQuestions");

		// Sets the text field
		finalText.text = string.Format("Game Over!\nYou answered {0} out of {1} correctly!\nThanks for playing!",numRight, totalQuestions);
	}
	
}
