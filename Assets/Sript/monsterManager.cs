using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterManager : MonoBehaviour {
    public GameObject monster1;

    private playerControl player;
    private float cd;
    private float constCD = 5f;

    private const int UP = 8;
    private const int DOWN = 2;
    private const int LEFT = 4;
    private const int RIGHT = 6;
    // Use this for initialization
    void Start () {
        cd = 1f;
        player = GameObject.FindWithTag("Player").GetComponent<playerControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.HP <= 0)
        {
            Destroy(gameObject);
            return;
        }

        //float[] range = { -1, 0, 1 };
        //Vector3 up, down, left, right;

        //up.y = down.y = left.y = right.y = 0.25f;
        //up.z = 5f;
        //down.z = -5f;
        //left.x = -8.75f;
        //right.x = 8.75f;

        if (cd <= 0)
        {
            int monsterNum;
            System.Random ran = new System.Random();

            //up
            monsterNum = ran.Next(0, 4);
            newMonster(monsterNum, UP);

            //down
            monsterNum = ran.Next(0, 4);
            newMonster(monsterNum, DOWN);

            //left
            monsterNum = ran.Next(0, 4);
            newMonster(monsterNum, LEFT);

            //right
            monsterNum = ran.Next(0, 4);
            newMonster(monsterNum, RIGHT);

            cd = constCD;
        }

      
        System.Random randomTime = new System.Random();
        cd -= (Time.deltaTime + randomTime.Next(-2, 5) / 10);
	}

    private void newMonster(int monsterNum, int direction){
        Vector3 loc1, loc2, loc3;
        loc1.y = loc2.y = loc3.y = 0.25f;

        switch(direction){
            case UP:
                loc1.z = loc2.z = loc3.z = 5f;
                loc1.x = 0;
                loc2.x = -1;
                loc3.x = 1;
                break;
            case DOWN:
                loc1.z = loc2.z = loc3.z = -5f;
                loc1.x = 0;
                loc2.x = -1;
                loc3.x = 1;
                break;
            case LEFT:
                loc1.x = loc2.x = loc3.x = -8.75f;
                loc1.z = 0;
                loc2.z = -1;
                loc3.z = 1;
                break;
            default:
                loc1.x = loc2.x = loc3.x = 8.75f;
                loc1.z = 0;
                loc2.z = -1;
                loc3.z = 1;
                break;
        }
        switch(monsterNum){
            case 0:
                break;
            case 1:
                Instantiate(monster1, loc1, Quaternion.identity);
                break;
            case 2:
                Instantiate(monster1, loc1, Quaternion.identity);
                Instantiate(monster1, loc2, Quaternion.identity);
                break;
            default:
                Instantiate(monster1, loc1, Quaternion.identity);
                Instantiate(monster1, loc2, Quaternion.identity);
                Instantiate(monster1, loc3, Quaternion.identity);
                break;

        }


    }

    private float GetRandom(float[] arr)
    {
        System.Random ran = new System.Random();
        int n = ran.Next(arr.Length);
        return arr[n];
    }
}
