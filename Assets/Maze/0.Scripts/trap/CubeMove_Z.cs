using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove_Z : MonoBehaviour
{
    public GameObject player;
    private float speed = 0.07f;


    bool isLeft = true;
    // Update is called once per frame
    void Update()
    {
        if (isLeft == true)
        {
            transform.Translate(Vector3.forward * speed);
            if (transform.localPosition.z > 52)
            {
                isLeft = false;
            }
        }

        else
        {
            transform.Translate(new Vector3(0, 0, -1) * speed);
            if (transform.localPosition.z < 37)
            {
                isLeft = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(player);
    }
}
