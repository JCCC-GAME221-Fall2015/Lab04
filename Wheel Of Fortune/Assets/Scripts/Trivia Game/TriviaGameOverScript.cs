using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TriviaGameOverScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		ShowCorrectCount();
		ShowWrongCount();

//		ShowScore();
//		if (GameHelperScript.gameScore > GameHelperScript.highScore)
//		{
//			GameHelperScript.SetHighScore(GameHelperScript.gameScore);
//			PlayerPrefs.SetInt("HighScore", GameHelperScript.gameScore);
//			PlayerPrefs.Save();
//			GameObject.Find ("NewHighScoreText").SetActive(true);
//		}
//		else
//			GameObject.Find ("NewHighScoreText").SetActive(false);
//		ShowHighScore();
//		if (GameHelperScript.allLevelsCompleted)
//			ShowAllLevels();
//		else
//		{
//			ShowLevels();
//			ShowPercentage();
//		}
//		ShowElapsedTime();
	}
	
//	public void LoadGameScene ()
//	{
//		Application.LoadLevel("GameScene");
//	}
//	
//	public void LoadMainMenuScene ()
//	{
//		Application.LoadLevel("MainMenuScene");
//	}
//	
//	public void ShowScore ()
//	{
//		GameObject.Find ("ScoreText2").GetComponent<Text>().text =
//			"Score: " + GameHelperScript.gameScore.ToString();
//	}
//	
//	public void ShowHighScore ()
//	{
//		GameObject.Find ("HighScoreText2").GetComponent<Text>().text =
//			"High Score: " + GameHelperScript.highScore.ToString();
//	}
//	
//	public void ShowLevels ()
//	{
//		if (GameHelperScript.completedLevels == 0)
//			GameObject.Find ("LevelText1").GetComponent<Text>().text = "You did not complete any levels";
//		else if (GameHelperScript.completedLevels == 1)
//			GameObject.Find ("LevelText1").GetComponent<Text>().text = "You successfully completed one level";
//		else
//			GameObject.Find ("LevelText1").GetComponent<Text>().text =
//				"You successfully completed " + GameHelperScript.completedLevels.ToString() + " levels";
//	}
//	
//	public void ShowPercentage ()
//	{
//		GameObject.Find ("LevelText2").GetComponent<Text>().text = "and completed " +
//			GameHelperScript.completedPercentage.ToString() + "% of level " +
//				(GameHelperScript.completedLevels + 1).ToString() + ".";
//	}
//	
//	public void ShowAllLevels ()
//	{
//		GameObject.Find ("LevelText1").GetComponent<Text>().text =
//			"Congratulations!";
//		GameObject.Find ("LevelText2").GetComponent<Text>().text =
//			"You successfully completed all levels!";
//	}
//	
//	public void ShowElapsedTime ()
//	{
//		GameObject.Find ("ElapsedTimeText").GetComponent<Text>().text =
//			"Total Elapsed Time:   " + GameHelperScript.elapsedTime.ToString() + " seconds.";
//	}
	
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
