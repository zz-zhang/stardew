using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour {
    public GameObject bullet;

    private playerControl player;
    private float cd;
    public float constCD = 0.25f;
    public float fastShootCD = 0f;
    public float shotGunCD = 0f;
    public float bulletDamage = 1f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<playerControl>();
        cd = -0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.HP < 0){
            return;
        }

        if (fastShootCD > 0)
        {
            constCD = 0.07f;
        }
        else{
            constCD = 0.25f;
        }

        if (cd < 0){
            int dirZ = 0;
            int dirX = 0;
            if (Input.GetKey(KeyCode.UpArrow)){
                dirZ = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow)){
                dirZ = -1;
            }

            if (Input.GetKey(KeyCode.LeftArrow)){
                dirX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow)){
                dirX = 1;
            }

            if (dirX != 0 || dirZ != 0)
            {
                GameObject newBul = Instantiate(bullet, player.transform.position + new Vector3(0.5f * dirX, 0, 0.5f * dirZ), Quaternion.identity);
                newBul.GetComponent<bulletControl>().bulletDirection = new Vector3(dirX, 0, dirZ);
                newBul.GetComponent<bulletControl>().bulletDamage = bulletDamage;
                if (shotGunCD > 0)
                {
                    Vector3 oriVec = new Vector3(dirX, 0, dirZ);
                    float rotationAngle = 20f;

                    Vector3 dir2 = Quaternion.AngleAxis(rotationAngle, Vector3.up) * oriVec;
                    GameObject newBul2 = Instantiate(bullet, player.transform.position + new Vector3(0.5f * dirX, 0, 0.5f * dirZ), Quaternion.identity);
                    newBul2.GetComponent<bulletControl>().bulletDirection = dir2;
                    newBul2.GetComponent<bulletControl>().bulletDamage = bulletDamage;

                    Vector3 dir3 = Quaternion.AngleAxis(-rotationAngle, Vector3.up) * oriVec;
                    GameObject newBul3 = Instantiate(bullet, player.transform.position + new Vector3(0.5f * dirX, 0, 0.5f * dirZ), Quaternion.identity);
                    newBul3.GetComponent<bulletControl>().bulletDirection = dir3;
                    newBul3.GetComponent<bulletControl>().bulletDamage = bulletDamage;
                }
                cd = constCD;
            }
        }
        cd -= Time.deltaTime;
        fastShootCD -= Time.deltaTime;
        shotGunCD -= Time.deltaTime;
	}


}
