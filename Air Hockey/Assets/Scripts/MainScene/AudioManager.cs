using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip puckCollision;
	public AudioClip goal;
	public AudioClip lostGame;
	public AudioClip winGame;

	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void playPuckCollision()
	{
		audioSource.PlayOneShot(puckCollision);
	}
	public void playGoal()
	{
		audioSource.PlayOneShot(goal);
	}
	public void playLostGame()
	{
		audioSource.PlayOneShot(lostGame);
	}
	public void playWinGame()
	{
		audioSource.PlayOneShot(winGame);
	}


}
