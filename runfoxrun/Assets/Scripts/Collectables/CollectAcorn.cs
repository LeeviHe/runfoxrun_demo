using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAcorn : MonoBehaviour {

    public AudioSource AcornSound;

    // Start is called before the first frame update
    void OnTriggerEnter( Collider other ) {
        UIControl.acornCount += 1;
        this.gameObject.SetActive(false);
        AcornSound.Play();
    }
}
