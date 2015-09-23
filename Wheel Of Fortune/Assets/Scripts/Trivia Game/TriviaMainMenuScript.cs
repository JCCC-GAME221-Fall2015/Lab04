using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriviaMainMenuScript : MonoBehaviour {
	
	public void LoadGameScene ()
	{
		Application.LoadLevel("GameScene");
	}
	
	public void LoadInstructionsScene ()
	{
		Application.LoadLevel("InstructionsScene");
	}
	
	public void QuitGame ()
	{
		Application.Quit();
		Debug.Log("Quit button clicked!");
	}
} // end class TriviaMainMenuScript
