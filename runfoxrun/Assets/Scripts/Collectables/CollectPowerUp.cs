using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{
    public bool powerUp = false;
    public AudioSource SpeedSound;

    private void OnTriggerEnter(Collider other)
    {

        powerUp = true;
        if (powerUp==true)
        {
            other.GetComponent<PowerUpBehavior>().ActivateSpeed();
            SpeedSound.Play();
            powerUp = false;
            this.gameObject.SetActive(false);
        }
       
    }

   


}
