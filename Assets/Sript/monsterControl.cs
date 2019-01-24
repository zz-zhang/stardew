using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControl : MonoBehaviour {
    public float HP;
    public float monsterSpeed;
    public Vector3 monsterDir;

    public GameObject itemShootSpeed;
    public GameObject itemIndecuHP;
    public GameObject itemShotGun;

    public float freeMoveCD;
    public float freeMoveTime;

    private float constFreeMoveCD = 5f;
    private float constFreeMoveTime = 0.5f;
    private playerControl player;
    private Rigidbody rb;
    private int fps;
	// Use this for initialization
	void Start () {
        HP = 2f;
        monsterSpeed = 1.5f;

        int seed = (int)(transform.position.x * 100) + (int)(transform.position.z * 100) + (int)(Time.time * 20);
        System.Random ran = new System.Random(seed);
        freeMoveCD = constFreeMoveCD + (float)ran.Next(-100, 100) / 100;
        freeMoveTime = constFreeMoveTime + (float)ran.Next(-100, 100) / 100;

        player = GameObject.FindWithTag("Player").GetComponent<playerControl>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0 || player.HP <= 0){
            if (HP <= 0)
            {
                player.score += 1;

                int seed = (int)(transform.position.x * 100) + (int)(transform.position.z * 100) + (int)(Time.time * 20);
                System.Random ran = new System.Random(seed);
                int item = ran.Next(0, 1000);
                Debug.Log(item);

                if (0 <= item && item < 75)
                {
                    //Debug.Log(transform.position);
                    Instantiate(itemShootSpeed, transform.position, itemShootSpeed.transform.rotation);
                }
                else if (75 <= item && item < 150)
                {
                    Instantiate(itemIndecuHP, transform.position, itemIndecuHP.transform.rotation);
                }
                else if (150 <= item && item < 225)
                {
                    Instantiate(itemShotGun, transform.position, itemIndecuHP.transform.rotation);
                }
            }
            Destroy(gameObject);
            return;
        }
        moveControl();
	}

    void moveControl(){

        if (freeMoveCD <= 0)
        {
            int seed = (int)(transform.position.x * 100) + (int)(transform.position.z * 100) + (int)(Time.time * 20);
            System.Random ran = new System.Random(seed);

            if (freeMoveTime > 0)
            {

                float x = (float)ran.Next(0, 100);
                float z = (float)ran.Next(0, 100);
                monsterDir.x = x;
                monsterDir.z = z;
                monsterDir = monsterDir.normalized;
                freeMoveTime -= Time.deltaTime;
            }
            else
            {
                freeMoveCD = constFreeMoveCD + (float)ran.Next(-100, 100) / 100;
                freeMoveTime = constFreeMoveTime + (float)ran.Next(-100, 100) / 100;
            }
        }
        else
        {
            monsterDir = player.transform.position - transform.position;
            monsterDir = monsterDir.normalized;
        }
            //rb.AddForce(monsterDir * monsterSpeed);
        transform.Translate(monsterDir * monsterSpeed * Time.deltaTime);
        freeMoveCD -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("get collision");
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<playerControl>().HP -= 1;
            HP -= 100;
        }
    }
}
