using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriviaGameOverScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		ShowCorrectCount();
		ShowWrongCount();
	}
	
	public void ShowCorrectCount()
	{
		GameObject.Find ("CorrectCountText").GetComponent<Text>().text =
			"Correct: " + TriviaGameHelperScript.correctCount.ToString();
	}
	
	public void ShowWrongCount()
	{
		GameObject.Find ("WrongCountText").GetComponent<Text>().text =
			"Wrong: " + TriviaGameHelperScript.wrongCount.ToString();
	}
	
	public void QuitGame ()
	{
		Application.Quit();
		Debug.Log("Quit button clicked!");
	}
}
