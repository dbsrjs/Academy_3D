using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        pos.z -= 5f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 7f);
    }
}
