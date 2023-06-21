using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        pos.y = target.position.y + 2.5f;
        pos.z = target.position.z - 2f;

        transform.position = Vector3.Lerp(target.position, pos, 1f);
    }
}
