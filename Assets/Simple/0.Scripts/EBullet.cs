using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 6) * 10;    //EBullet�� �ӵ� ����(max spped = 50f)
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)     //gameObject�� �浹�� ����
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}