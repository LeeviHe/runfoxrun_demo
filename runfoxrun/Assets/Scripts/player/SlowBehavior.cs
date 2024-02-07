using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehavior : MonoBehaviour
{
    public float timer = 0f;
    public GameObject player;
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
            player.GetComponent<playerMovement>().moveSpeed = 1;
            if (player.GetComponent<playerMovement>().newHit==true)
            {
                timer = 0f;
                player.GetComponent<playerMovement>().newHit = false;
                Debug.Log("uusi slow");
            }
            if (timer > 3f)
            {
                player.GetComponent<playerMovement>().moveSpeed = 3;
                player.GetComponent<playerMovement>().isHitted = false;
                timer = 0f;
                Debug.Log("slow poistui");

            }
            
        }
      
    
    }
}
