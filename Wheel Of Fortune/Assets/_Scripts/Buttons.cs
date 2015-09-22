using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Buttons 
/// </summary>
public class Buttons : MonoBehaviour {
    #region Fields

    public string wheels = "Wheels";
    public string trivia = "Trivia";

    #endregion

    public void LoadWheels() {
        Application.LoadLevel(wheels);
    }

    public void LoadTrivia() {
        Application.LoadLevel(trivia);
    }

}