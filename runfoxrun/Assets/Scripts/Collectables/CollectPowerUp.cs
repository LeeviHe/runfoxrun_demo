using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{
    public bool powerUp = false;
    public AudioSource SpeedSound;
    public int id;

    private void OnTriggerEnter(Collider other)
    {

       
        if (powerUp==false)
        {
            powerUp=true;
            // Speed PowerUp id is 0
            if (powerUp==true && id==0)
            {
                other.GetComponent<PowerUpBehavior>().ActivateSpeed();
                SpeedSound.Play();
                powerUp = false;
                this.gameObject.SetActive(false);
            }
            // Flying PowerUp id is 1
            if (powerUp == true && id == 1)
            {
                other.GetComponent<PowerUpBehavior>().ActivateFlying();
                powerUp = false;
                this.gameObject.SetActive(false);
                Debug.Log("Tähän tulee lento");
            }

        }
       
    }

   


}
