using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : MonoBehaviour {
    public bulletManager gun;

    public float appearCD = 10f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (appearCD <= 0)
        {
            Destroy(gameObject);
        }


        if (Mathf.Abs(transform.position.y + 10f) > 0.1f)
            appearCD -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gun.shotGunCD <= 0)
            {
                gun.shotGunCD = 5f;
            }
            else
            {
                gun.shotGunCD += 5f;
            }
            Destroy(gameObject);
        }

    }
}