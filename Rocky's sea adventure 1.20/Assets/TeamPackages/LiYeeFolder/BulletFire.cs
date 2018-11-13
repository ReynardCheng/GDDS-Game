using System.Collections;
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
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;

        }
        else
        {
            // Otherwise destroy self
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject); //destroy itself
            return;
        }
    }
}
