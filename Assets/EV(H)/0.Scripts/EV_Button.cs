using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EV_Button : MonoBehaviour
{
    [SerializeField] private GameObject lDoor;
    [SerializeField] private GameObject rDoor;
    // Start is called before the first frame update
    void Start()
    {
        /*
        while (true)
        {
            if (lDoor.transform.localPosition.y >= 0.7)
            {
                Vector3 lpos = lDoor.transform.localPosition;
                lpos.z = 0.7f;
                lDoor.transform.localPosition = lpos;

                Vector3 rpos = rDoor.transform.localPosition;
                rpos.z = -0.7f;
                rDoor.transform.localPosition = rpos;

                break;
            }
            rDoor.transform.Translate(new Vector3(0f, 0f, 0.5f));
            lDoor.transform.Translate(new Vector3(0f, 0f, -0.5f));
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_1F()
    {
        lDoor.transform.Translate(new Vector3(0f, 0f, 0.55f));
    }
}
