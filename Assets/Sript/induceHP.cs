using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class induceHP : MonoBehaviour {

    public playerControl player;
    public float appearCD = 10f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<playerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (appearCD <= 0)
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
            player.HP += 1;
            Destroy(gameObject);
        }

    }
}
