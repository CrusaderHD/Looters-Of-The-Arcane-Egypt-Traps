using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {


	public ArrowTrap arrowScript;
	public float arrowSpeed;
	private float time = 0f;
	public float arrowDelay;

	public float minTime;
	public float maxTime;

	public bool shooting;

	private Vector3 direction2;


	// Use this for initialization
	void Start () {
		direction2 = new Vector3(0,0,arrowSpeed);
		shooting = false;
		StartCoroutine(arrowTimer());
	}
	
	// Update is called once per frame
	void Update () {

		if (shooting == true)
		{
			if(time <= 0)
			{
				ArrowTrap arrow = Instantiate (arrowScript, transform.position, transform.rotation) as ArrowTrap;
				arrow.direction = direction2;
				time = Random.Range(minTime, maxTime);
			}
		}
	}


	IEnumerator arrowTimer()
	{
		while(true)
		{
			time -= .1f;
			yield return new WaitForSeconds(.1f);
		}
	}



}
