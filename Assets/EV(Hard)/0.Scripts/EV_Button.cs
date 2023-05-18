using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EV_Button : MonoBehaviour
{
    public Transform left;
    public Transform right;

    void Start()
    {
        OpenDoor();
    }

    //min : 0.25f, max : 0.7f
    public void OpenDoor()
    {
        if (left.transform.localPosition.z <= 0.25f)
        {
            left.Translate(new Vector3(0f, 0f, 0.5f));
        }

        if (right.transform.localPosition.z <= -0.25f)
        {
            right.Translate(new Vector3(0f, 0f, -0.5f));
        }
    }

    public void ExitDoor()
    {
        if (left.transform.localPosition.z >= 0.7f)
        {
            left.Translate(new Vector3(0f, 0f, -0.5f));
        }

        if (right.transform.localPosition.z >= -0.7f)
        {
            right.Translate(new Vector3(0f, 0f, 0.7f));
        }
    }
}
