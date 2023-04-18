using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Transform cam;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 15f;   //A, D
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * 15f; //W, s        

        Vector3 moveDir = new Vector3(x, 0, z);

        //회전 변환만 적용
        moveDir = cam.TransformDirection(moveDir);

        transform.Translate(moveDir);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Key")
        {
            door.SetActive(false);
            door.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject);
        }
    }
}
