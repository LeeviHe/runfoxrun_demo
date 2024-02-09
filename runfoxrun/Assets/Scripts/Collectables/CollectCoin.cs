using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    public AudioSource CoinSound;

    void OnTriggerEnter( Collider other ) {
            UIControl.coinCount += 1;
            this.gameObject.SetActive( false );
            CoinSound.Play();
    }
}
