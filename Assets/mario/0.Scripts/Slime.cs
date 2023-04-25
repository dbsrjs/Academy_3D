using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftRay();
        RightRay();
    }

    void LeftRay()
    {
        Vector3 leftPos = transform.position;
        leftPos.x -= 0.2f;
        Debug.DrawRay(leftPos, Vector3.down * 0.4f, Color.red);

        Ray ray = new Ray(leftPos, Vector3.down * 0.4f);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
        }
    }

    void RightRay()
    {
        Vector3 rightPos = transform.position;
        rightPos.x += 0.2f;
        Debug.DrawRay(rightPos, Vector3.down * 0.4f, Color.red);
    }
}
