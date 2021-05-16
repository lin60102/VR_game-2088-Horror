using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TragUp : MonoBehaviour
{

    Vector3 PlayerPosition;
    Quaternion PlayerRotation;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = transform.position;
        PlayerRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y !=0.04)
        {

            transform.position = new Vector3(transform.position.x, 0.019f, transform.position.z);
        }
    }
}
