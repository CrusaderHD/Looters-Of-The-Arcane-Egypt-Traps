using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour {

	Rigidbody rb;
    //Allows desiginer access to change which direction 
    //and how fast the arrow moves.
    //LeftWallArrows need to move acorss the -Z axis whereas RightWallArrows need to move across the Z Axis
    public Vector3 direction = new Vector3(0,0,0); 
    


	// Use this for initialization
	void Start () {
		//Get Component of Arrow Rigidbody
		//Add force and speed to the arrow
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = direction;
	}
}
