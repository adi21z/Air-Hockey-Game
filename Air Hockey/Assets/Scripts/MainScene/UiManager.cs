using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	[Header("Canvas")]
	public GameObject canvasGame;
	public GameObject canvasRestart;

	[Header("CanvasRestart")]
	public GameObject winTxt;
	public GameObject lostTxt;

	[Header("other")]
	public AudioManager audioManager;
	public ScoreScript scoreScript;

	public PuckScript puckScript;
	public Player1Movement player1Movement;
	public Player2Movement player2Movement;
	public AIScript aIScript;

	public void showRestartCanvas(bool didAiWin)
	{
		Time.timeScale = 0;

		canvasGame.SetActive(false);
		canvasRestart.SetActive(true);
		if (didAiWin)
		{
			audioManager.playLostGame();
			winTxt.SetActive(false);
			lostTxt.SetActive(true);

		}
		else
		{
			audioManager.playWinGame();
			winTxt.SetActive(true);
			lostTxt.SetActive(false);
		}





	}
	public void RestartGame()
	{
		Time.timeScale = 1;
		canvasGame.SetActive(true);
		canvasRestart.SetActive(false);

		scoreScript.ResetScore();
		puckScript.centerPuck();

		player1Movement.ResetPosition();
		player2Movement.ResetPosition();
		aIScript.ResetPosition();
	}
	public void showMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("menu");
	}






	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
