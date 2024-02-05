using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class playerMovement : MonoBehaviour
{
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
    public GameObject foxCoin;
    private int health = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  fox now will run forward automatically
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed,Space.World);
        // input to go left
        if (Input.GetKey(KeyCode.A)) 
        {
            // will check if you are too close to level boundaries this is for left side
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
            
        }
        // -1 will invert the number and we are moving right
        if (Input.GetKey(KeyCode.D))
        {
            // will check if you are too close to level boundaries this is for right side
            if(this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(isJumping == false)
            {
                isJumping = true;
                //playerObject.GetComponent<Animator>().Play("Fox_Jump");
                playerObject.GetComponent<Animator>().SetBool("isJumping", true);
                playerObject.GetComponent<Animator>().SetBool("comingDown", false);
                StartCoroutine(JumpSequence());
            }
        }
        if(isJumping == true)
        {
            if(comingDown == false)
            {
                
                transform.Translate(Vector3.up * Time.deltaTime * jumpPower,Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpPower, Space.World);
                
                
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
        playerObject.GetComponent<Animator>().SetBool("isMoving",true);
        playerObject.GetComponent<Animator>().SetBool("isJumping", false);
        playerObject.GetComponent<Animator>().SetBool("comingDown", false);
    }

    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.name != foxCoin.gameObject.name) {
            if (health > 1) {
                playerObject.GetComponent<Animator>().Play("Hit");
                other.gameObject.SetActive(false);
                Debug.Log("-1 hp");
                health--;
                Debug.Log(health);
            } else {
                Debug.Log("död");
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                playerObject.GetComponent<Animator>().Play("Fox_Falling");
                thePlayer.GetComponent<playerMovement>().enabled = false;
            }

        }
        
    }
}
