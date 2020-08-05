using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuckRestriction : MonoBehaviour {


	public Transform BoundaryHolderPuck;
	public Transform puckPos;
	public Rigidbody puckRb;
	Boundary playerBoundary;
	float speed;
	bool clicked=false;
	[SerializeField] private float maxSpeedPuck;

	
	// Use this for initialization
	void Start () {
		
		playerBoundary = new Boundary(BoundaryHolderPuck.GetChild(0).position.z,
			BoundaryHolderPuck.GetChild(1).position.z, BoundaryHolderPuck.GetChild(2).position.x, BoundaryHolderPuck.GetChild(3).position.x);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		puckRb.velocity = Vector3.ClampMagnitude(puckRb.velocity, maxSpeedPuck);
		
		//Vector3 clampedPuckPos = new Vector3(Mathf.Clamp(puckPos.position.x, playerBoundary.Left, playerBoundary.Right), puckPos.position.y, Mathf.Clamp(puckPos.position.z, playerBoundary.Down, playerBoundary.Up));
		//puckPos.position = clampedPuckPos;
		
		speed = puckRb.velocity.magnitude;
		if (clicked)
		{
			if (speed < 2f)
			{

				puckRb.AddForce((Random.Range(-1,2)) * 0.005f, 0, (Random.Range(-1,2)) * 0.005f);
			}
		}
		if (Input.GetMouseButton(0))
		{
			clicked = true;
		}


	}
	











}
