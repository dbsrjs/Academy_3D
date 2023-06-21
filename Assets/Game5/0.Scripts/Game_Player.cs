using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Player : MonoBehaviour
{
    [HideInInspector] public bool isStart = false;
    [HideInInspector] public bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Door")
        {
           //Game5Cont.Find(DoorAnimation).GetComponent<Animator>().
        }

        if (other.name == "EndBox")
        {
            isFinish = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (true)
        {

        }

        if (other.name == "StartLine")
        {
             isStart = true;
        }
    }

    public void Dead()
    {
        //GetComponent<Animtor>().SetTrigger("Wave");
    }
}
