using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All hinges are being spoken of from looking down(forwards) of the Z-Axis. When the Z-Axis arrow is pointing straight in front of you as if you were looking at it or following it.
public enum RotationAxis{frontHinge, backHinge, leftHinge, rightHinge}; 
//FrontHinge = -X , BackHinge = +X , RightHinge = +Z , LeftHinge = -Z (Front and Back Hinges are on X-Axis Rotations, Left and Right hinges are on Z-Axis Rotations).

public enum direction{Negative, Positive};
//FrontHinge and LeftHinge operate on Negative Direction, BackHinge and RightHinge operate on Positive Direction.

public class Trapdoor : MonoBehaviour {

	public RotationAxis rotAxis;
	public GameObject trapDoor;
	private GameObject frontHinge;
	private GameObject backHinge;
	private GameObject leftHinge;
	private GameObject rightHinge;
	public bool playerTrapped;
	public GameObject frontDoor;
	public GameObject backDoor;
	public GameObject leftDoor;
	public GameObject rightDoor;


	void Start()
	{
		playerTrapped = false;
	}


	void Update()
	{
		if(rotAxis == RotationAxis.frontHinge)
		{
			if(playerTrapped)
			{
				frontHinge = GameObject.Find("FrontHinge");
				frontHinge.GetComponent<Animation>().Play("FrontTrapHinge");
				backDoor.GetComponent<MeshRenderer>().enabled =false;
				leftDoor.GetComponent<MeshRenderer>().enabled =false;
				rightDoor.GetComponent<MeshRenderer>().enabled =false;
			}
		}
		else if(rotAxis == RotationAxis.backHinge)
		{
			if(playerTrapped)
			{
				backHinge = GameObject.Find("BackHinge");
				backHinge.GetComponent<Animation> ().Play("BackTrapHinge");
				frontDoor.GetComponent<MeshRenderer>().enabled =false;
				leftDoor.GetComponent<MeshRenderer>().enabled =false;
				rightDoor.GetComponent<MeshRenderer>().enabled =false;
			}
		}
		else if(rotAxis == RotationAxis.leftHinge)
		{
			if(playerTrapped)
			{
				leftHinge = GameObject.Find("LeftHinge");
				leftHinge.GetComponent<Animation> ().Play("LeftTrapHinge");
				backDoor.GetComponent<MeshRenderer>().enabled =false;
				frontDoor.GetComponent<MeshRenderer>().enabled =false;
				rightDoor.GetComponent<MeshRenderer>().enabled =false;
			}
		}
		else if(rotAxis == RotationAxis.rightHinge)
		{
			if(playerTrapped)
			{
				rightHinge = GameObject.Find("RightHinge");
				rightHinge.GetComponent<Animation> ().Play("RightTrapHinge");
				backDoor.GetComponent<MeshRenderer>().enabled =false;
				leftDoor.GetComponent<MeshRenderer>().enabled =false;
				frontDoor.GetComponent<MeshRenderer>().enabled =false;
			}
		}
		else
		{
			playerTrapped = false;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			playerTrapped = true;
		}
		else
		{
			playerTrapped = false;
		}
	}
}
