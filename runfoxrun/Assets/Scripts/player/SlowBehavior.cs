using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehavior : MonoBehaviour
{
    public float timer = 0f;
    public GameObject player;
    public GameObject anim;
    public GameObject powerUp;
    public bool slowAdded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if player is hitted 
        if(player.GetComponent<playerMovement>().isHitted == true)
        {
            // start timer when hitted 
            timer += Time.deltaTime;
           //check if slow is added
            if (slowAdded==false)
            {
                // slows player movement speed forward and left and right also animation speed is slowed
                player.GetComponent<playerMovement>().moveSpeed = 1;
                player.GetComponent<playerMovement>().leftRightSpeed = 1;
                anim.GetComponent<Animator>().SetFloat("speed", 0.5f);
                anim.GetComponent<Animator>().SetBool("isSlowed", true);
                anim.GetComponent<Animator>().SetBool("isMoving", false);
                slowAdded = true;
                Debug.Log("Slow alkoi");
            }
            // checks if player is hitted again 
            if (player.GetComponent<playerMovement>().newHit == true)
            {
                // set timer back to 0 and keeps old slows
                timer = 0f;
                player.GetComponent<playerMovement>().moveSpeed = 1;
                player.GetComponent<playerMovement>().leftRightSpeed = 1;
                anim.GetComponent<Animator>().SetFloat("speed", 0.5f);
                anim.GetComponent<Animator>().SetBool("isSlowed", true);
                anim.GetComponent<Animator>().SetBool("isMoving", false);
                player.GetComponent<playerMovement>().newHit = false;
                Debug.Log("uusi slow");
            }
            // check if player gets powerUp
            if (powerUp.GetComponent<CollectPowerUp>().powerUp == true )
            {
                
                // player animation is setted back to normal and powerUp clears slow effect off
                anim.GetComponent<Animator>().SetFloat("speed", 1f);
                player.GetComponent<playerMovement>().isHitted = false;
                anim.GetComponent<Animator>().SetBool("isSlowed", false);
                anim.GetComponent<Animator>().SetBool("isMoving", true);
                timer = 0f;
                slowAdded = false;
                Debug.Log("slowin aikana otettu power up");
            }
            // player has hitted object with power up and 3s has passed
            if (timer > 3f && player.GetComponent<PowerUpBehavior>().isSpeedActive)
            {
                // setting normal animation speed and setting timer to 0
                player.GetComponent<playerMovement>().isHitted = false;
                anim.GetComponent<Animator>().SetFloat("speed", 1f);
                timer = 0f;

                anim.GetComponent<Animator>().SetBool("isSlowed", false);
                anim.GetComponent<Animator>().SetBool("isMoving", true);
                slowAdded = false;
                Debug.Log("slow poistui speedi on powerupin varainen");
            }
            // 3s has passed normally waiting
            if (timer > 3f)
            {
                // setting normal movement speed and animations also setting timer to 0 
                player.GetComponent<playerMovement>().moveSpeed = 3;
                player.GetComponent<playerMovement>().leftRightSpeed = 3;
                player.GetComponent<playerMovement>().isHitted = false;
                anim.GetComponent<Animator>().SetFloat("speed", 1f);
                timer = 0f;
                slowAdded = false;
                anim.GetComponent<Animator>().SetBool("isSlowed", false);
                anim.GetComponent<Animator>().SetBool("isMoving", true);
                
                Debug.Log("slow poistui normaali speed");

            }
            
        }
      
    
    }
}
