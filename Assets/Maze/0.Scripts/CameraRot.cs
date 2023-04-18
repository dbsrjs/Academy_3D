using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    float rotX, rotY;

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");

        rotY += mX * 500f * Time.deltaTime;
        rotX += mY * 500f * Time.deltaTime;

        if (rotX > 35f)
            rotX = 35;

        if (rotX < -30)
            rotX = -30;

        transform.eulerAngles = new Vector3(-rotX, rotY, 0f);

    }
}
