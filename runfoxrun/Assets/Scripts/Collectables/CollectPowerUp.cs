using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{
    public bool powerUp = false;

    private void OnTriggerEnter(Collider other)
    {
        powerUp = true;
        this.gameObject.SetActive(false);
    }

   


}
