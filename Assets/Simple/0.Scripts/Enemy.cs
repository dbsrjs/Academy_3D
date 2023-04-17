using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EBullet bullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private Transform parent;
    float speed = 1;

    bool isLeft = true;

    float fireDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 5) * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        fireDelay += Time.deltaTime;
        if (fireDelay > 0.5f)
        {
            fireDelay = 0;
            Instantiate(bullet, firePos).transform.SetParent(parent);
        }

        if (isLeft == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < -4)
            {
                isLeft = false;
                speed = Random.Range(2, 5) * 2f;
            }
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > 4)
            {
                isLeft = true;
                speed = Random.Range(2, 5) * 2f;
            }
        }
    }
}
