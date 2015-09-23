using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriviaInstructionsScript : MonoBehaviour {
	
	public void LoadGameScene ()
	{
		Application.LoadLevel("GameScene");
	}
	
	public void LoadMainMenuScene ()
	{
		Application.LoadLevel("MainMenuScene");
	}
}
