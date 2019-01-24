using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpeedControl : MonoBehaviour {


    public bulletManager gun;

    public float itemSpeedCD = 10f;
    public float appearCD = 10f;

    private bool cached = false;
    // Use this for initialization
    void Start () {
        gun = GameObject.FindWithTag("Weapon").GetComponent<bulletManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(appearCD <= 0)
        {
            Destroy(gameObject);
        }

        //Debug.Log(itemSpeedCD);

        if (Mathf.Abs(transform.position.y + 10f) > 0.1f)
            appearCD -= Time.deltaTime;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gun.fastShootCD <= 0)
            {
                gun.fastShootCD = 5f;
            }
            else{
                gun.fastShootCD += 5f;
            }
            Vector3 outOfMap = new Vector3(-10, -10, -10);
            transform.position = outOfMap;
            appearCD = 100f;
            cached = true;
            Destroy(gameObject);
            //Debug.Log(gun.constCD);
            //Debug.Log(transform.position);

        }

    }

}
