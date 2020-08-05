using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Aiplayer;
 

    void Start()
    {
        if (GameValues.isMultiplayer)
        {
           // Aiplayer.GetComponent<PlayerMovement>().enabled = true;
            Aiplayer.GetComponent<AIScript>().enabled = false;

        }
        else
        {
          //  Aiplayer.GetComponent<PlayerMovement>().enabled = false;
            Aiplayer.GetComponent<AIScript>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
