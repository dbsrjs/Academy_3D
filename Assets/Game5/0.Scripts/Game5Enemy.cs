using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Enemy : MonoBehaviour
{
    [SerializeField] private Game_Player p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(p.transform);
    }
}
