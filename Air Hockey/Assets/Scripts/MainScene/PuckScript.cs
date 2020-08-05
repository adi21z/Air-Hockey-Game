using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour {
	public ScoreScript ScoreScriptInstance;
	public static bool wasGoal { get; private set; }
	private Rigidbody rb;
	public AudioManager audioManager;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		wasGoal = false;
	}
	
	// Update is called once per frame
	void Update () {



	}
	private void OnTriggerEnter(Collider other)
	{
		if (!wasGoal)
		{
			if (other.tag == "AiGoal")
			{
				ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
				wasGoal = true;
				audioManager.playGoal();
				StartCoroutine(ResetPuck(false));
			}
			else if (other.tag == "PlayerGoal")
			{
				ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
				wasGoal = true;
				audioManager.playGoal();
				StartCoroutine(ResetPuck(true));
			}
		}

	}
	private void OnCollisionEnter(Collision collision)
	{
		
		audioManager.playPuckCollision();
	}
	public void centerPuck()
	{
		rb.position = new Vector3(-0.058f, 0.14f, -11.222f);
	}


	private IEnumerator ResetPuck(bool didAiScore)
	{
		yield return new WaitForSecondsRealtime(1);
		wasGoal = false;
		rb.velocity = new Vector3(0, 0, 0);
		if (didAiScore)
		{
			rb.position = new Vector3(-0.024f,0.14f,-11.516f);
		}
		else
		{
			rb.position = new Vector3(-0.036f,0.14f,-10.92f);
		}
	}







}


