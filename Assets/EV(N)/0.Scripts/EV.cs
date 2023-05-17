using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EV : MonoBehaviour
{
    [System.Serializable]
    public struct Door  //struct�� �⺻���� ����� �� �� ����(class�� ����)
    {
        public Transform left;
        public Transform right;
    }

    public Door fDoor;
    public Door bDoor;

    [SerializeField] List<Transform> floors;

    int currentFloor = 0;   //���� ��

    bool isUp = true;

    float doorSpeed = 0.1f;
    void Start()
    {
        //Invoke("Move", 2f);
        Move();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        { 
            StartCoroutine("MainEV");
        }      
    }
    void Move()
    {
        StartCoroutine(MainEV());
    }

    IEnumerator MainEV()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine("DoorAnimation");
        yield return StartCoroutine("CMove");
    }
    IEnumerator DoorAnimation()
    {
        //������ Z ���� �����ش�.
        //�ʱⰪ�� 0.25 �ƽ� ���� 0.84
        yield return new WaitForSeconds(1.5f);

        while (true)    //����
        {
            if(fDoor.left.localPosition.x >= 0.84)
            {
                Vector3 lpos = fDoor.left.localPosition;
                lpos.x = 0.84f;
                fDoor.left.localPosition = lpos;

                Vector3 rpos = fDoor.right.localPosition;
                rpos.x = -0.84f;
                fDoor.right.localPosition = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(0.05f, 0f, 0f));
            fDoor.right.Translate(new Vector3(-0.05f, 0f, 0f));

            yield return new WaitForSeconds(Time.deltaTime * doorSpeed);    //delay Time
        }

        yield return new WaitForSeconds(1.5f);

        while (true)    //����
        {
            if (fDoor.left.localPosition.x <= 0.25)
            {
                Vector3 lpos = fDoor.left.localPosition;
                lpos.x = 0.25f;
                fDoor.left.localPosition = lpos;

                Vector3 rpos = fDoor.right.localPosition;
                rpos.x = -0.25f;
                fDoor.right.localPosition = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(-0.01f, 0, 0));
            fDoor.right.Translate(new Vector3(0.01f, 0, 0));

            yield return new WaitForSeconds(Time.deltaTime * doorSpeed);    //delay Time
        }

        yield return null;
    }

    IEnumerator CMove() //�� �� �̵�
    {
        while (true)
        {
            if (isUp)   //6���� �����ϸ� 1������ ��������
            {
                if (transform.localPosition.y >= floors[currentFloor].localPosition.y)
                {                    
                    Vector3 vec = transform.localPosition;
                    vec.y = floors[currentFloor].localPosition.y;
                    transform.localPosition = vec;                    
                    break;
                }
                transform.Translate(Vector3.up * Time.deltaTime * 30f);
            }
            else
            {
                //??
            }
            transform.Translate(Vector3.up * Time.deltaTime * 30f);

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);  //delay Time
        if (isUp)   //6���� �����ϸ� 1������ ��������
        {
            isUp = false;
            currentFloor--;
        }            
        else
        {
            currentFloor--;
            if (currentFloor <= 0)
                isUp = true;
        }
        StartCoroutine("CMove");
    }
}
