using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

	public float maxMovementSpeed;
	private Rigidbody rb;
	private Vector3 startingPosition;

	public Rigidbody Puck;

	public Transform playerBoundaryHolder;
	private Boundary playerBoundary;

	public Transform puckBoundaryHolder;
	private Boundary puckBoundary;

	private Vector3 targetPosition;
	private bool isFirstTimeInOpponentsHalf;
	private float offsetFromTarget;




	// Use this for initialization
	private void Start () {
		rb = GetComponent<Rigidbody>();
		startingPosition = rb.position;

		playerBoundary= new Boundary(playerBoundaryHolder.GetChild(0).position.z,
			playerBoundaryHolder.GetChild(1).position.z, playerBoundaryHolder.GetChild(2).position.x, playerBoundaryHolder.GetChild(3).position.x);
		puckBoundary= new Boundary(puckBoundaryHolder.GetChild(0).position.z,
			puckBoundaryHolder.GetChild(1).position.z, puckBoundaryHolder.GetChild(2).position.x, puckBoundaryHolder.GetChild(3).position.x);

	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		if (!PuckScript.wasGoal)
		{
			float movementSpeed;
			if (Puck.position.z < puckBoundary.Down)
			{
				if (isFirstTimeInOpponentsHalf)
				{
					isFirstTimeInOpponentsHalf = false;
					offsetFromTarget = Random.Range(-1f, 1f);
				}



				movementSpeed = maxMovementSpeed * Random.Range(0.1f, 0.3f);
				targetPosition = new Vector3(Mathf.Clamp(Puck.position.x + offsetFromTarget, playerBoundary.Left, playerBoundary.Right), Puck.position.y, startingPosition.z);
			}
			else
			{
				isFirstTimeInOpponentsHalf = true;
				movementSpeed = Random.Range(maxMovementSpeed * 0.2f, maxMovementSpeed);
				targetPosition = new Vector3(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right), Puck.position.y, Mathf.Clamp(Puck.position.z, playerBoundary.Down, playerBoundary.Up
					));
			}

			rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

		}
	}
	public void ResetPosition()
	{
		rb.position = startingPosition;
	}

}
