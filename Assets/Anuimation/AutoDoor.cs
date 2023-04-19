using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [SerializeField] Animator animtor;

    [SerializeField] AnimationClip openClop;
    [SerializeField] AnimationClip closeClop;

    [SerializeField] Animation anim;
    void Start()
    {
        anim.AddClip(openClop, "open");
        anim.AddClip(closeClop, "close");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //animtor.SetTrigger("open");
            anim.Play("open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //animtor.SetTrigger("close");
            anim.Play("close");
        }
    }
}
