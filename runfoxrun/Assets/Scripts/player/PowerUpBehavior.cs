using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject animatio;
    public float duration = 5f;
    public float speedIncrease = 5f;
    public bool isSpeedActive = false;
    public float baseSpeed = 3;


    // Update is called once per frame
    void Update()
    {
        if(powerUp.GetComponent<CollectPowerUp>().powerUp == true)
        {
            if (!isSpeedActive)
            {
                Debug.Log("Power up iffissä");
                ActivateSpeed();
            }
            powerUp.GetComponent<CollectPowerUp>().powerUp = false;
            Debug.Log("Power up done");
        }
    }
    void ActivateSpeed()
    {
        this.gameObject.GetComponent<playerMovement>().moveSpeed = this.gameObject.GetComponent<playerMovement>().moveSpeed + speedIncrease;
        isSpeedActive = true;
        animatio.GetComponent<Animator>().SetFloat("speed", 1.5f);
        Debug.Log("Speediä");
        Debug.Log(this.gameObject.GetComponent<playerMovement>().moveSpeed);
        StartCoroutine(DeActivateSpeed());
    }
    IEnumerator DeActivateSpeed()
    {
        yield return new WaitForSeconds(duration);
        this.gameObject.GetComponent<playerMovement>().moveSpeed = baseSpeed;
        animatio.GetComponent<Animator>().SetFloat("speed", 1f);
        isSpeedActive = false;
        
        Debug.Log("Speedi loppu");

    }
}
