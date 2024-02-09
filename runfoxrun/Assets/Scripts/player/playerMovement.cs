using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class playerMovement : MonoBehaviour
{
    public Transform cameraRootTransform; //player camera root

    // puclic variant for movementspeed can be changed in unity editor
    public float moveSpeed = 3;
    // public variant for left or right movementspeed
    public float leftRightSpeed = 4;
    // Start is called before the first frame update
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public GameObject thePlayer;
    public float jumpPower = 3;
    public GameObject foxCoinPrefab;
    public GameObject acornPrefab;
    public bool isHitted = false;
    public bool newHit = false;
    public AudioSource HitSound;
    public AudioSource RipSound;
    public AudioSource JumpSound;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = 10f;
        float rotationAngle = 0f;

        //  fox now will run forward automatically
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed,Space.World);

        // input to go left and will check if you are too close to level boundaries this is for left side
        if (Input.GetKey(KeyCode.A) && (this.gameObject.transform.position.x > LevelBoundary.leftSide)) {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                rotationAngle = -45f;
        } 
        //moving right + will check if you are too close to level boundaries this is for right side
        else if (Input.GetKey(KeyCode.D) && (this.gameObject.transform.position.x < LevelBoundary.rightSide)) {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed, Space.World);
                rotationAngle = 45f;
        }

        Quaternion targetRotation = Quaternion.Euler(0, rotationAngle, 0);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        // Lock y and z rotation of the camera while preserving x rotation
        Quaternion currentCameraRotation = cameraRootTransform.rotation;
        Quaternion lockedRotation = Quaternion.Euler(currentCameraRotation.eulerAngles.x, 0f, 0f);
        cameraRootTransform.rotation = lockedRotation;
        if (Input.GetKey(KeyCode.W))
        {
            if(isJumping == false)
            {
                isJumping = true;
                //playerObject.GetComponent<Animator>().Play("Fox_Jump");
                playerObject.GetComponent<Animator>().SetBool("isJumping", true);
                playerObject.GetComponent<Animator>().SetBool("comingDown", false);
                JumpSound.Play();
                StartCoroutine(JumpSequence());
            }
        }
        if(isJumping == true)
        {
            if(comingDown == false)
            {
                
                transform.Translate(Vector3.up * Time.deltaTime * jumpPower,Space.World);
                transform.Translate(Vector3.forward * Time.deltaTime * 0.5f, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpPower, Space.World);
                transform.Translate(Vector3.forward * Time.deltaTime * 0.5f, Space.World);


            }
        }
        

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        playerObject.GetComponent<Animator>().SetBool("comingDown", true);
        playerObject.GetComponent<Animator>().SetBool("isJumping", false);
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        if (thePlayer.GetComponent<SlowBehavior>().slowAdded)
        {
           playerObject.GetComponent<Animator>().SetBool("isSlowed", true);
        }
        else
        {
            playerObject.GetComponent<Animator>().SetBool("isMoving", true);
        }
        playerObject.GetComponent<Animator>().SetBool("isJumping", false);
        playerObject.GetComponent<Animator>().SetBool("comingDown", false);
    }
  IEnumerator HitSequence()
    {
        playerObject.GetComponent<Animator>().Play("Hit");
        yield return new WaitForSeconds(0.65f);
        playerObject.GetComponent<Animator>().Play("Run");

    }

    private void OnTriggerEnter( Collider other ) {
        //Check if triggering object is coin or acorn -> should they take damage
        if (other.gameObject.CompareTag("Collectable")) {
            Debug.Log("Collectable collected!");
        } else {
            if (other.gameObject.CompareTag("Obstacle")) {
                //If player has health -> hit animation and -1 health
                if (Health.health > 1) {
                    playerObject.GetComponent<Animator>().Play("Hit");
                    HitSound.Play();
                    other.gameObject.SetActive(false);
                    Debug.Log("-1 hp");
                    Health.health--;
                    if (isHitted == true) {
                        newHit = true;
                    } else {
                        isHitted = true;
                    }

                    StartCoroutine(HitSequence());
                } // player doesn't have enough health -> player loses
                else {
                    Health.health = 0;
                    thePlayer.GetComponent<playerMovement>().enabled = false;
                    playerObject.GetComponent<Animator>().Play("Fox_Falling");
                    RipSound.Play();
                }
            } else {
                Debug.Log("Empty collision trigger");
            }
        } 
    }       
}
