using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Force unity to add the TriviaReferences script if it is not already on the object
[RequireComponent(typeof(TriviaReferences))]
public class TriviaEngine : MonoBehaviour {
	
	const int NUM_ANSWERS = 4; // number of answers per question
	
	TriviaReferences refs;
	private int questionCount = 0;
	private int rightCount = 0;
	private int wrongCount = 0;
	private int currentQuestion = 0;

	private GameObject canvasObject;
	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;
	private Text button1Text;
	private Text button2Text;
	private Text button3Text;
	private Text button4Text;
	private Text questionText;
	private string outputString;
	private string[] questionArray;
	private string[] correctAnswers;
	private string[] wrongAnswers1;
	private string[] wrongAnswers2;
	private string[] wrongAnswers3;
//	private int numQuestions = 0; // number of questions in input file
//	private int answerCounter = 0; // counter for current element in answers list
	private int correctButton = 0; // number of button containing the correct answer
	private bool waitingForKey = false;
	private bool keyHasBeenPressed = false;


//	int points;
//	string word = "  Luck Be       In The         Air        Tonight"; //Stores the phrase the player should guess
//	string hint = "Phrases";                    //Stores the hint provided to the player 
//	int charGoal = 0;                           //Stores how many letters the player needs to guess
//	int charGot = 0;                            //Tracks how many letters the player has already guessed
	
	/// <summary>
	/// Called by TriviaReferences once it is done gathering all necessary information
	/// Starts the game
	/// </summary>
	void Begin()
	{
		//Gets a link to the TriviaReferences script
		refs = gameObject.GetComponent<TriviaReferences>();
		canvasObject = GameObject.Find("Canvas");
		button1 = GameObject.Find("Answer1Button");
//		outputString = "Button 1 Name: " + button1.name.ToString();
//		Debug.Log (outputString);
		button2 = GameObject.Find("Answer2Button");
//		outputString = "Button 2 Name: " + button2.name.ToString();
//		Debug.Log (outputString);
		button3 = GameObject.Find("Answer3Button");
//		outputString = "Button 3 Name: " + button3.name.ToString();
//		Debug.Log (outputString);
		button4 = GameObject.Find("Answer4Button");
//		outputString = "Button 4 Name: " + button4.name.ToString();
//		Debug.Log (outputString);

		button1Text = button1.GetComponentInChildren<Text>();
//		outputString = "Button 1 Text: " + button1Text.text.ToString();
//		Debug.Log (outputString);
		button2Text = button2.GetComponentInChildren<Text>();
//		outputString = "Button 2 Text: " + button2Text.text.ToString();
//		Debug.Log (outputString);
		button3Text = button3.GetComponentInChildren<Text>();
//		outputString = "Button 3 Text: " + button3Text.text.ToString();
//		Debug.Log (outputString);
		button4Text = button4.GetComponentInChildren<Text>();
//		outputString = "Button 4 Text: " + button4Text.text.ToString();
//		Debug.Log (outputString);
		questionText = GameObject.Find("QuestionText").GetComponent<Text>();

		questionArray = GetComponent<TriviaReferences>().questionArray;
		correctAnswers = GetComponent<TriviaReferences>().correctAnswers;
		wrongAnswers1 = GetComponent<TriviaReferences>().wrongAnswers1;
		wrongAnswers2 = GetComponent<TriviaReferences>().wrongAnswers2;
		wrongAnswers3 = GetComponent<TriviaReferences>().wrongAnswers3;
		questionCount = questionArray.Length;
//		numQuestions = correctAnswers.Length;
//		outputString = "Number of questions: " + numQuestions.ToString();
//		Debug.Log (outputString);

		//Starts the game
		StartGame();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (keyHasBeenPressed)
		{
			keyHasBeenPressed = false;
			currentQuestion++;
			if (currentQuestion < questionCount)
			{
				correctButton = Random.Range(1, NUM_ANSWERS + 1);
				DisplayQuestionAndAnswers(correctButton, currentQuestion);
			}
			else
			{
				outputString = "Game Over!  Correct: " + rightCount.ToString() +
					"  Wrong: " + wrongCount.ToString();
				Debug.Log (outputString);
			}
		}
	} // end method Update

	/// <summary>
	/// Called by buttons in the scene to check the players input.
	/// </summary>
	/// <param name="letter">The letter to check against the phrase the player is guessing</param>
	public void CheckLetter(string letter)
	{
//		//Find the button the player clicked and disable it so it cannot be clicked again
//		GameObject.Find(letter).GetComponent<Button>().interactable = false;       
//		
//		//Start off pessimestic and assume the player didn't click a letter in the phrase
//		bool found = false;
//		
//		//If the letter the player guessed in a space character, ignore it
//		if (letter == " ")
//			return;
//		
//		//Start looking at each and every character in the string holding the phrase the player is guessing
//		for (int i = 0; i < word.Length; i++)
//		{
//			//If the current character is a space, ignore it
//			if (word[i] == ' ')
//			{
//				continue;
//			}
//			
//			//If the current character is the same letter the player guessed
//			if (word[i] == letter[0])
//			{
//				//Show the letter on the screen for the player
//				refs.letters[i].text = letter.ToString();
//				//Change the background of the letter to something lighter
//				refs.correct[i].enabled = true;
//				//Hide the "unfilled" background so the lighter colour will show
//				refs.unfilled[i].enabled = false;
//				//Inform the algorithm a match has been found
//				found = true;
//				//Store that the player has found one more letter towards the goal
//				charGot++;
//			}
//		}
//		
//		//Debug.Log("Got: " + charGot + " goal: " + charGoal);
//		
//		//If the player has found a letter, award them points
//		//Otherwise, take their points
//		if (found)
//			points++;
//		else
//			points--;
//		
//		//If the player has no points left, end the game
//		if (points <= 0)
//			EndGame();
//		
//		//If the player has guessed all the letters, win the game
//		if (charGot >= charGoal)
//			WinGame();
//		
//		//Show the user their new score
//		refs.score.text = points.ToString();
//		
	}
	
	/// <summary>
	/// Shows a win image, a short text informing the player they won, and a restart button
	/// </summary>
	void WinGame()
	{
//		refs.gameWonImage.enabled = true;
//		refs.gameWonText.enabled = true;
//		refs.gameWonButton.SetActive(true);
	}
	
	/// <summary>
	/// Shows the player the answer, an image, a short text saying they lost, and a restart button
	/// </summary>
	void EndGame()
	{
//		//Go through each letter in the phrase the player is supposed to guess
//		for (int i = 0; i < word.Length; i++)
//		{
//			//Skip spaces
//			if (word[i] == ' ')
//			{
//				continue;
//			}
//			//Display the letter to the player
//			refs.letters[i].text = word[i].ToString();
//		}
//		
//		refs.gameOverImage.enabled = true;
//		refs.gameOverText.enabled = true;
//		refs.gameOverButton.SetActive(true);
	}
	
	public void PressButton1()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			if (correctButton == 1)
			{
				rightCount++;
				outputString = "Correct count:" + rightCount.ToString();
				Debug.Log (outputString);
			}
			else
			{
				wrongCount++;
				outputString = "Wrong count:" + wrongCount.ToString();
				Debug.Log (outputString);
			}
			keyHasBeenPressed = true;
		}
	}
	
	public void PressButton2()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			if (correctButton == 2)
			{
				rightCount++;
				outputString = "Correct count:" + rightCount.ToString();
				Debug.Log (outputString);
			}
			else
			{
				wrongCount++;
				outputString = "Wrong count:" + wrongCount.ToString();
				Debug.Log (outputString);
			}
			keyHasBeenPressed = true;
		}
	}
	
	public void PressButton3()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			if (correctButton == 3)
			{
				rightCount++;
				outputString = "Correct count:" + rightCount.ToString();
				Debug.Log (outputString);
			}
			else
			{
				wrongCount++;
				outputString = "Wrong count:" + wrongCount.ToString();
				Debug.Log (outputString);
			}
			keyHasBeenPressed = true;
		}
	}
	
	public void PressButton4()
	{
		if (waitingForKey)
		{
			waitingForKey = false;
			if (correctButton == 4)
			{
				rightCount++;
				outputString = "Correct count:" + rightCount.ToString();
				Debug.Log (outputString);
			}
			else
			{
				wrongCount++;
				outputString = "Wrong count:" + wrongCount.ToString();
				Debug.Log (outputString);
			}
			keyHasBeenPressed = true;
		}
	}

	private void DisplayQuestionAndAnswers(int correctButton, int questionNumber)
	{
		questionText.text = questionArray[questionNumber];
		switch (correctButton)
		{
			case 1:
				button1Text.text = correctAnswers[questionNumber];
				button2Text.text = wrongAnswers1[questionNumber];
				button3Text.text = wrongAnswers2[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			case 2:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = correctAnswers[questionNumber];
				button3Text.text = wrongAnswers2[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			case 3:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = wrongAnswers2[questionNumber];
				button3Text.text = correctAnswers[questionNumber];
				button4Text.text = wrongAnswers3[questionNumber];
				break;
			default:
				button1Text.text = wrongAnswers1[questionNumber];
				button2Text.text = wrongAnswers2[questionNumber];
				button3Text.text = wrongAnswers3[questionNumber];
				button4Text.text = correctAnswers[questionNumber];
				break;
		}
		keyHasBeenPressed = false;
		waitingForKey = true;
	} // end method SetButtonAnswers
	
	/// <summary>
	/// Sets all player data to default values 
	/// </summary>
	public void StartGame()
	{
		rightCount = 0;
		wrongCount = 0;
		currentQuestion = 0;
		waitingForKey = false;
		keyHasBeenPressed = false;

		correctButton = Random.Range(1, NUM_ANSWERS + 1);
		DisplayQuestionAndAnswers(correctButton, currentQuestion);

//		while (currentQuestion < questionCount)
//		{
//			correctButton = Random.Range(1, NUM_ANSWERS + 1);
//			DisplayQuestionAndAnswers(correctButton, currentQuestion);
//		}


//		//Sets the goal, and how many letters the player has guessed to zero
//		charGoal = 0;
//		charGot = 0;
//		
//		int numSent = refs.sentences.Count;
//		int randomSent = Random.Range(0, numSent);
//		
//		word = refs.sentences[randomSent];
//		hint = refs.clues[randomSent];
//		
//		//If there are too many letters in the phrase, skip it 
//		//Probably some more robust error checking and fail-safe should happen here
//		if (word.Length > 51)
//		{
//			Debug.Log("PHRASE TO LONG!");
//			return;
//		}
//		
//		//Disable all game over/won images, texts, and buttons
//		refs.gameOverImage.enabled = false;
//		refs.gameOverText.enabled = false;
//		refs.gameWonImage.enabled = false;
//		refs.gameWonText.enabled = false;
//		refs.gameOverButton.SetActive(false);
//		refs.gameWonButton.SetActive(false);
//		
//		//Convert the phrase to uppercase for comparison with player input
//		word = word.ToUpper();
//		
//		//Go through each letter display on screen and erase all text
//		//Also, hide all indications that a letter should belong there
//		for (int i = 0; i < 52; i++)
//		{
//			refs.letters[i].text = "";
//			refs.unfilled[i].enabled = false;
//			refs.correct[i].enabled = false;
//		}
//		
//		//Set up to split up the phrase based on spaces
//		char[] delimiterCharacters = { ' ' };
//		
//		//Split the phrase at every space
//		string[] words = word.Split(delimiterCharacters);
//		
//		//Set the inital amount of points to (number of letters)/3
//		points = (words.Length)/3;
//		
//		//Make sure the player starts with at LEAST three points
//		if(points < 3)
//			points = 3;
//		
//		//Show the player their starting points
//		refs.score.text = points.ToString();
//		
//		//Display where letters will appear on the board
//		for (int i = 0; i < word.Length; i++)
//		{
//			//Skip spaces
//			if (word[i] == ' ')
//			{
//				continue;
//			}
//			
//			refs.unfilled[i].enabled = true;
//			//keep track of how many letters there are
//			charGoal++;
//			
//		}
//		
//		//Show the player the hint
//		refs.hint.text = hint;
//		
//		//Enable all of the buttons on the screen so the player can interact again
//		foreach(Button bt in refs.buttons)
//		{
//			bt.interactable = true;
//		}
	} // end method StartGame
} // end class TriviaEngine
