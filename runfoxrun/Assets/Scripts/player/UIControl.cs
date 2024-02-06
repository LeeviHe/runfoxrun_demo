using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public static int coinCount;
    public static int acornCount;
    public static int playerHealth = 3;
    public GameObject coinCountDisplay;
    public GameObject playerHealthDisplay;
    public GameObject acornCountDisplay;

    // Update is called once per frame
    void Update() {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        acornCountDisplay.GetComponent<Text>().text = "" + acornCount;
        playerHealthDisplay.GetComponent<Text>().text = "" + playerHealth;
    }
}
