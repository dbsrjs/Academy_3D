using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public float followSpeed = 0.15f;

    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("player");            
    }

    void FixedUpdate()
    {
        Vector3 camera_pes = player.transform.position = offset;
        Vector3 lerp_pos = Vector3.Lerp(transform.position, camera_pes, followSpeed);
        transform.position = lerp_pos;
        transform.LookAt(player.transform);
    }
}
