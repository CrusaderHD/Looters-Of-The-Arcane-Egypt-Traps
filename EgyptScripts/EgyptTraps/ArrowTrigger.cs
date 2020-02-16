using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour {



	public ArrowSpawner [] arrowSpawnerList;




	void Start()
	{
		arrowSpawnerList = GetComponentsInChildren<ArrowSpawner>();
	}



	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			for(int i = 0; i < arrowSpawnerList.Length; i++)
			{
				arrowSpawnerList[i].shooting = true;
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			for(int i = 0; i < arrowSpawnerList.Length; i++)
			{
				arrowSpawnerList[i].shooting = false;
			}
	}

}
