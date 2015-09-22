using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriviaMainMenuScript : MonoBehaviour {
	
	// Use this for initialization
//	void Start () {
//
//	}
	
	public void LoadGameScene ()
	{
		Application.LoadLevel("GameScene");
	}
	
	public void LoadInstructionsScene ()
	{
//		Application.LoadLevel("InstructionsScene");
	}
	
	public void QuitGame ()
	{
		Application.Quit();
		Debug.Log("Quit button clicked!");
	}
} // end class TriviaMainMenuScript
