using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // puclic variant for movementspeed can be changed in unity editor
    public float moveSpeed = 3;
    // public variant for left or right movementspeed
    public float leftRightSpeed = 4;
    // Start is called before the first frame update
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

    }
}
