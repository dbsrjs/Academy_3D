using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<SimpleSampleCharacterControl>())
        {
            other.transform.GetComponent<SimpleSampleCharacterControl>().Jump();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
