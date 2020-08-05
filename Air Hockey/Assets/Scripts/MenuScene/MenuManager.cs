using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{

	public void playGame()
	{
		SceneManager.LoadScene("main");
	}
	public void setMultiplayer(bool isOn)
	{
		GameValues.isMultiplayer = isOn;
		SceneManager.LoadScene("main");
	}
}
