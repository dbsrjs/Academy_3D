using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.6f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(player);
    }
}
