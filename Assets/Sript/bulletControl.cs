using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

    public Vector3 bulletDirection;
    public float bulletSpeed = 10f;
    public float bulletDamage = 1f;

    private int fps = 60;
	// Use this for initialization
	void Start () {

        Rigidbody rb = GetComponent<Rigidbody>();
        bulletDirection = bulletDirection.normalized;
        rb.AddForce(bulletDirection * bulletSpeed * fps);
        //Debug.Log(bulletDirection);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        //Debug.Log("get collision");
        Destroy(gameObject);
        if (collision.collider.tag == "Monster"){
            collision.collider.GetComponent<monsterControl>().HP -= bulletDamage;
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag != "Bullet" && other.tag != "Item")
            Destroy(gameObject);
        if (other.tag == "Monster"){
            other.GetComponent<monsterControl>().HP -= bulletDamage;
        }
	}
}
