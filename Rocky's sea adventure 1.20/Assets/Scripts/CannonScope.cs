using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScope : MonoBehaviour {

	public GameObject linkedCannon;
	CannonFire linkedCannonFire;

	// Use this for initialization
	void Start () {
		linkedCannonFire = linkedCannon.GetComponent<CannonFire>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) //Add enemy to list of targets when in range of cannon
	{
		if (other.gameObject.tag == "Enemy")
		{
			linkedCannonFire.EnemiesInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) //Remove enemy from target list when it leaves range
	{
		if (other.gameObject.tag == "Enemy")
		{
			linkedCannonFire.EnemiesInRange.Remove(other.gameObject);
		}
	}
}
