using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private float speed = 0.06f;


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
}
