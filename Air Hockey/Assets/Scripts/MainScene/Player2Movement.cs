
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startingPosition;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startingPosition = rb.position;
    }
    void Update()
    {

    }
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }




}
