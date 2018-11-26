using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	public GameObject bullet;
	public bool shipDetetected;
	[SerializeField] float fireRate;
	[SerializeField] float coolDownTime;
    public DetectShipTrigger DetectShipTrigger;

	// Use this for initialization
	void Start () {
		fireRate = 0f;
		coolDownTime = 3f;
	}
	
	// Update is called once per frame
	void Update () {


		if (DetectShipTrigger.shipDetected) //changed
		{
			FireRate();
			Shoot();
            shipDetetected = true;
		}
	}

	void Shoot()
	{
		if (shipDetetected && fireRate <= 0)
		{
			Instantiate(bullet, transform.position,Quaternion.identity);
		}

		if(fireRate <= 0) fireRate = coolDownTime;


	}

	void FireRate()
	{
		if (fireRate > 0f)
		{
			fireRate -= Time.deltaTime;
		}
	}


    //CHANGED and moved to DetectShipTrigger under TriggerHolder child
	/*private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ship")
		{
			shipDetetected = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Ship")
		{
			shipDetetected = false;
		}
	}*/

}
