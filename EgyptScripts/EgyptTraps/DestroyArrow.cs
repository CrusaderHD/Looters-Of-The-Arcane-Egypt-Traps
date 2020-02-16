using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour {

	public float destroyTimer = 0.0f;
	public int damage;

	void Start()
	{
		Destroy (gameObject, destroyTimer);
	}

	void update()
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject == GameManager.instance.player.gameObject) 
		{
			Health hp = other.gameObject.GetComponent<Health> ();
			hp.TakeDamage (damage);
			Destroy (gameObject);
			Debug.Log ("Hit");
		}
	}

}
