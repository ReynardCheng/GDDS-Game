using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCannon: MonoBehaviour {
    
    public GameObject cannonPrefab;

    private bool canBuild;
    private bool slotTaken; // == true when a cannon is already built in position
       
    
    // Use this for initialization
    void Start () {
        slotTaken = false;
        CheckForCannon();
	}
	
	// Update is called once per frame
	void Update () {
        BuildTower();
	}

    void CheckForCannon()   //Runs at beginning of game to "start" the default cannons
    {
        if (transform.childCount > 0)
        {
           // linkedCannonFire = GetComponentInChildren<CannonFire>();
            slotTaken = true;
        }
    }

    void BuildTower()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuild && !slotTaken)
        {
            GameObject newCannon;
            newCannon = Instantiate(cannonPrefab, transform.position, cannonPrefab.transform.rotation);
			//newCannon.transform.Rotate(transform.localRotation.eulerAngles.z, cannonPrefab.transform.rotation.y, cannonPrefab.transform.rotation.z);
			newCannon.GetComponent<CannonFire>().Unparent();
			slotTaken = true;
        }

    }
	void OnTriggerEnter(Collider other) //Add enemy to list of targets when in range of cannon
	{
		if (other.gameObject.tag == "Player")
		{
			canBuild = true;
		}
	}

	void OnTriggerExit(Collider other) //Remove enemy from target list when it leaves range
	{
	
		if (other.gameObject.tag == "Player")
		{
			canBuild = false;
		}
	}

}
