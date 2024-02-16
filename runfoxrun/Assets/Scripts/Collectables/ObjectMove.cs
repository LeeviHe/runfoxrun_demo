using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject feather;
    public float speed;
    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1);
        feather.transform.position = new Vector3(feather.transform.position.x, y, feather.transform.position.z);
    }
}
