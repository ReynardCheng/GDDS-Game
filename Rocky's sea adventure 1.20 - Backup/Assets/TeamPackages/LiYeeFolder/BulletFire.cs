﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    public float speed = 10;
    public Transform target;  //Target (set by CannonFire script)}

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update () {
        if (target) //if enemy target exists
        {
            // Fly towards the target
            
			GetComponent<Rigidbody>().velocity = MathScript.ShootInArc(target, this.transform, 60f);
			transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f);
        }
        else
        {
            // Otherwise destroy self
            Destroy(gameObject);
        }

    }
	//Vector3 ShootInArc(float angle)
	//{
	//	Vector3 dir = target.position - transform.position;  // get target direction
	//	float h = dir.y;  // get height difference
	//	dir.y = 0;  // retain only the horizontal direction
	//	var dist = dir.magnitude;  // get horizontal distance
	//	var a = angle * Mathf.Deg2Rad;  // convert angle to radians
	//	dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
	//	dist += h / Mathf.Tan(a);  // correct for small height differences
	//							   // calculate the velocity magnitude
	//	var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
	//	return vel * dir.normalized;
	//}
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject); //destroy itself
            return;
        }
    }
}
