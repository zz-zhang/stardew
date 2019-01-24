using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {
    private const int MOVE_UP = 1;
    private const int MOVE_DOWN = -1;
    private const int MOVE_RIGHT = 1;
    private const int MOVE_LEFT = -1;

    public float HP;
    public int score = 0;

    public Text scoreText;
    public Text hpText;
    public GameObject gameoverText;




    private float moveSpeed;
    private int moveDirectionX;
    private int moveDirectionY;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        HP = 5;
        moveSpeed = 3.0f;
        moveDirectionX = 0;
        moveDirectionY = 0;

	}
	
	// Update is called once per frame
	void Update () {
        string scoreStr = "Score: " + score.ToString();
        scoreText.text = scoreStr;

        string hpStr = "HP: " + HP.ToString();
        hpText.text = hpStr;

        if (HP <= 0){
            gameoverText.SetActive(true);
            Destroy(gameObject);
            return;
        }

        float keyVertical = Input.GetAxis("Vertical");
        float keyHorizontal = Input.GetAxis("Horizontal");

        if (keyHorizontal > 0)
            moveDirectionX = MOVE_RIGHT;
        else if (keyHorizontal < 0)
            moveDirectionX = MOVE_LEFT;
        else moveDirectionX = 0;
        if (keyVertical > 0)
            moveDirectionY = MOVE_UP;
        else if (keyVertical < 0)
            moveDirectionY = MOVE_DOWN;
        else moveDirectionY = 0;

        if (moveDirectionX == MOVE_LEFT)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (moveDirectionX == MOVE_RIGHT)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (moveDirectionY == MOVE_UP)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (moveDirectionY == MOVE_DOWN)
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            
	}


}
