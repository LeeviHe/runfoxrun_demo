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
    public bool isFlying = false;
    public bool isGliding = false;
    public bool jumpStart = false;




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
     

        Debug.Log("Speedi�");
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

    public void ActivateFlying()
    {
        
        this.gameObject.GetComponent<playerMovement>().moveSpeed = this.gameObject.GetComponent<playerMovement>().moveSpeed + speedIncrease;
        //left and right movement speed
        this.gameObject.GetComponent<playerMovement>().leftRightSpeed = this.gameObject.GetComponent<playerMovement>().leftRightSpeed + speedIncrease;
        thePlayer.GetComponent<Rigidbody>().useGravity=false;
        StartCoroutine(FlyingSequence());
    }
    IEnumerator FlyingSequence()
    {
        isFlying = true;
        jumpStart = true;
        animatio.GetComponent<Animator>().SetBool("isMoving", false);
        animatio.GetComponent<Animator>().SetBool("comingDown", false);
        animatio.GetComponent<Animator>().SetBool("isJumping", true);
        yield return new WaitForSeconds(0.5f);
        jumpStart = false;
        isGliding = true;
        animatio.GetComponent<Animator>().SetBool("isMoving", false);
        animatio.GetComponent<Animator>().SetBool("comingDown", false);
        animatio.GetComponent<Animator>().SetBool("isJumping", false);
        animatio.GetComponent<Animator>().SetBool("isGliding", true);
        // adding particle system for speed boost 
        Instantiate(particleEffect, thePlayer.gameObject.transform);
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<playerMovement>().moveSpeed = baseSpeed;
        this.gameObject.GetComponent<playerMovement>().leftRightSpeed = baseSpeedLeftAndRight;
        thePlayer.GetComponent<Rigidbody>().useGravity = true;
        isGliding = false;
        yield return new WaitForSeconds(0.5f);
        animatio.GetComponent<Animator>().SetBool("isGliding", false);
        animatio.GetComponent<Animator>().SetBool("comingDown", false);
        animatio.GetComponent<Animator>().SetBool("isJumping", false);
        animatio.GetComponent<Animator>().SetBool("isMoving", true);
        isFlying = false;





        Debug.Log("Flying loppu");

    }
}
