using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject powerUp;
    public GameObject animatio;
    public GameObject particleEffect;
    public float duration = 5f;
    public float speedIncrease = 5f;
    public bool isSpeedActive = false;
    public float baseSpeed = 3;
    public float baseSpeedLeftAndRight = 3;



    // Update is called once per frame

   //activate speed
    public void ActivateSpeed()
    {
        // forward movement speed
        this.gameObject.GetComponent<playerMovement>().moveSpeed = this.gameObject.GetComponent<playerMovement>().moveSpeed + speedIncrease;
        //left and right movement speed
        this.gameObject.GetComponent<playerMovement>().leftRightSpeed = this.gameObject.GetComponent<playerMovement>().leftRightSpeed + speedIncrease;
        isSpeedActive = true;
         //run animation speed 
        animatio.GetComponent<Animator>().SetFloat("speed", 1.5f);
     

        Debug.Log("Speediä");
        Debug.Log(this.gameObject.GetComponent<playerMovement>().moveSpeed);
        StartCoroutine(DeActivateSpeed());
    }
    IEnumerator DeActivateSpeed()
    {
        // adding particle system for speed boost 
        Instantiate(particleEffect, thePlayer.gameObject.transform);
        yield return new WaitForSeconds(duration);
        // returning normal running speed
        this.gameObject.GetComponent<playerMovement>().moveSpeed = baseSpeed;
        this.gameObject.GetComponent<playerMovement>().leftRightSpeed = baseSpeedLeftAndRight;
        // returning normal animation speed for run animation
        animatio.GetComponent<Animator>().SetFloat("speed", 1f);
        isSpeedActive = false;

        

        Debug.Log("Speedi loppu");

    }
}
