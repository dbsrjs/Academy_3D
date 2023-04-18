using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove_Y : MonoBehaviour
{
    public GameObject player;
    private float speed = 0.05f;

    bool isLeft = true;
    
    // Update is called once per frame
    void Update()
    {
        if (isLeft == true)
        {
            transform.Translate(Vector3.up * speed);
            if (transform.localPosition.y > 11)
            {
                isLeft = false;
            }
        }

        else
        {
            transform.Translate(new Vector3(0, -1, 0) * speed);
            if (transform.localPosition.y < 1)
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
