using UnityEngine;
using System;
using System.Collections;

public static class TriviaGameHelperScript {
	public static int correctCount {get; private set;}
	public static int wrongCount {get; private set;}

	public static void SetCorrectCount (int newCorrectCount)
	{
		correctCount = newCorrectCount;
	}
	
	public static void SetWrongCount (int newWrongCount)
	{
		wrongCount = newWrongCount;
	}
} // end class TriviaGameHelperScript
