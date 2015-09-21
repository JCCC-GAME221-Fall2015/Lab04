using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(TriviaReferences))]
public class TriviaEngine : MonoBehaviour 
{
    References refs;
    int score;
    int question;

    void Begin()
    {
        refs = gameObject.GetComponent<References>();

    }

    public void CheckAnswer(string answer)
    {
        

    }
}
