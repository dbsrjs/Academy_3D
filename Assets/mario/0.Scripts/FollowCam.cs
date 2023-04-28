using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<SimpleSampleCharacterControl>().transform;
            return;
        }
        Vector3 pos = target.position;
        pos.z -= 3f;
        pos.y += 1f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 7f);
    }
}
