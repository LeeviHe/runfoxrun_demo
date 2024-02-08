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
        if(player.GetComponent<playerMovement>().isHitted == true)
        {
            timer += Time.deltaTime;
            if (slowAdded==false)
            {
                
                player.GetComponent<playerMovement>().moveSpeed = 1;
                player.GetComponent<playerMovement>().leftRightSpeed = 1;
                anim.GetComponent<Animator>().SetFloat("speed", 0.5f);
                anim.GetComponent<Animator>().SetBool("isSlowed", true);
                anim.GetComponent<Animator>().SetBool("isMoving", false);
                slowAdded = true;
                Debug.Log("Slow alkoi");
            }
     
            if (player.GetComponent<playerMovement>().newHit == true)
            {
                timer = 0f;
                player.GetComponent<playerMovement>().moveSpeed = 1;
                player.GetComponent<playerMovement>().leftRightSpeed = 1;
                anim.GetComponent<Animator>().SetFloat("speed", 0.5f);
                anim.GetComponent<Animator>().SetBool("isSlowed", true);
                anim.GetComponent<Animator>().SetBool("isMoving", false);
                player.GetComponent<playerMovement>().newHit = false;
                Debug.Log("uusi slow");
            }
            if (powerUp.GetComponent<CollectPowerUp>().powerUp == true )
            {
                
                player.GetComponent<playerMovement>().leftRightSpeed = 3;
                anim.GetComponent<Animator>().SetFloat("speed", 1f);    

                anim.GetComponent<Animator>().SetBool("isSlowed", false);
                anim.GetComponent<Animator>().SetBool("isMoving", true);

                Debug.Log("slowin aikana otettu power up");
            }
            if (timer > 3f && player.GetComponent<PowerUpBehavior>().isSpeedActive)
            {
                player.GetComponent<playerMovement>().leftRightSpeed = 3;
                player.GetComponent<playerMovement>().isHitted = false;
                anim.GetComponent<Animator>().SetFloat("speed", 1f);
                timer = 0f;

                anim.GetComponent<Animator>().SetBool("isSlowed", false);
                anim.GetComponent<Animator>().SetBool("isMoving", true);
                slowAdded = false;
                Debug.Log("slow poistui speedi on powerupin varainen");
            }
            if (timer > 3f)
            {
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
