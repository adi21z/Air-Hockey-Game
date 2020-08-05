using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {
	public enum Score
	{
		AiScore,PlayerScore
	}

	public Text AiScoreText, PlayerScoreText;
	public UiManager uiManager;

	public int MaxScore;
	private int aiScore, playerScore;

	private int AiScore
	{
		get { return aiScore; }
		set
		{
			aiScore = value;
			if (value == MaxScore)
			{
				uiManager.showRestartCanvas(false);
			}
		}
	}
	private int PlayerScore
	{
		get { return playerScore; }
		set
		{
			playerScore = value;
			if (value == MaxScore)
			{
				uiManager.showRestartCanvas(true);
			}
		}
	}





	public void Increment(Score whichScore)
	{
		if (whichScore==Score.AiScore)
		{
			AiScoreText.text = (++AiScore).ToString();

		}
		else
		{
			PlayerScoreText.text = (++PlayerScore).ToString();
		}
	}
	public void ResetScore()
	{
		AiScore = PlayerScore = 0;
		AiScoreText.text = PlayerScoreText.text = "0";
	}


	// Use this for initialization
	void Start () {

		AiScoreText.color = Color.blue;
		PlayerScoreText.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
