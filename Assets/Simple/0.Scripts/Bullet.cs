using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);    //Bullet�� 3�ʰ� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);
    }

    void OnTriggerEnter(Collider other)     //gameObject�� �浹�� ����
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
