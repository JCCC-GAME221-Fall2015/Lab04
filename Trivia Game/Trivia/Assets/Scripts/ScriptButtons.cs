using UnityEngine;
using System.Collections;

public class ScriptButtons : MonoBehaviour
{

    // Button to start the game
    public void _BtnStartGame()
    {
        Application.LoadLevel("SceneGameScreen");
    }

    // Button to exit the game
    public void _BtnExit()
    {
        Application.Quit();
    }

    // Button to load the main menu
    public void _BtnMainMenu()
    {
        Application.LoadLevel("SceneStartMenu");
    }
}
