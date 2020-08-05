using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryExplosion : MonoBehaviour {

	public GameObject explosionSystem;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "LeftBorder"|| other.gameObject.tag == "RightBorder" || other.gameObject.tag == "UpBorder" || other.gameObject.tag == "DownBorder")
		{
			if (explosionSystem != null)
			{
				Instantiate(explosionSystem, transform.position, Quaternion.identity);
			}
		}
	}





}
