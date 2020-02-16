using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArrowShooter : MonoBehaviour {

	public GameObject arrowPrefab;
	public GameObject[] testArrowList;

	public float fireRateMin;
	public float fireRateMax;
	public float cooldownMin;
	public float cooldownMax;
	public float cooldownTimer;

	public bool playerInTrigger;
	public bool canShoot;
	public bool shooting;



	// Use this for initialization
	void Start ()
	{
		//testArrowList = GetComponentInChildren<testArrowList>();

		cooldownTimer = Random.RandomRange(cooldownMin, cooldownMax);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInTrigger)
		{
			if(canShoot)
			{
				for(int i = 0; i < testArrowList.Length; i++)
				{
					ShootArrow(i);
					shooting = true;
				}
			}
			else
			{
				cooldownTimer -= Time.deltaTime;

				if(cooldownTimer <= 0)
				{
					canShoot = true;
					cooldownTimer = Random.RandomRange(cooldownMin, cooldownMax);
				}
			}
		}
	}

	void ShootArrow(int number)
	{
		Transform spawnLocation = testArrowList [number].transform;
		GameObject fireArrowInstance = Instantiate(arrowPrefab, spawnLocation.position, spawnLocation.rotation) as GameObject; // add ,spawnLocation after the rotation to shoot while rotating and follow
		Rigidbody rb = fireArrowInstance.GetComponent<Rigidbody>();
		rb.AddForce (fireArrowInstance.transform.forward * Random.RandomRange(fireRateMin, fireRateMax));
		canShoot = false;
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			playerInTrigger = true;
		}

	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			playerInTrigger = false;
		}
	}

}
