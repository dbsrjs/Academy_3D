using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private Transform parent;

    float fireDealy = 10;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 6f; //A, D
        //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * 6f;   W, S

        transform.Translate(x, 0f, 0f);

        fireDealy += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (fireDealy > 0.2f)
            {
                fireDealy = 0;
                Bullet b = Instantiate(bullet, firePos);    //bullet 생성
                b.transform.SetParent(parent);  //parent 변경
            }           
        }
    }
}
