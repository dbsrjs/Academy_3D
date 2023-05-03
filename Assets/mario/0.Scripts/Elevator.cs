using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
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

    float doorSpeed = 4f;   //�� ���ݴ� �ӵ�
    float speed = 20f;   //Elevator �ӵ�(Y)

    Door curDoor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainEV());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            StartCoroutine("MainEV");
        }        
    }

    IEnumerator MainEV()
    {
        curDoor = currentFloor == 0 ? fDoor : bDoor;
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine("DoorAnimation");
        yield return StartCoroutine("CMove");
    }
    
    IEnumerator DoorAnimation()
    {
        //������ Z ���� �����ش�.
        //�ʱⰪ�� 0.25 �ƽ� ���� 0.84
        
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine("OpenDoor");
        yield return StartCoroutine("CloseDoor");
    }

    IEnumerator OpenDoor()      //�� ����
    {
        while (true)
        {
            if (curDoor.left.localPosition.x >= 0.84)
            {
                Vector3 lpos = curDoor.left.localPosition;    //����
                lpos.x = 0.84f;
                curDoor.left.localPosition = lpos;

                Vector3 rpos = curDoor.right.localPosition;   //������
                rpos.x = -0.84f;
                curDoor.right.localPosition = rpos;

                break;
            }
            curDoor.left.Translate(new Vector3(0.01f, 0, 0));
            curDoor.right.Translate(new Vector3(-0.01f, 0, 0));

            yield return new WaitForSeconds(Time.deltaTime * doorSpeed);
        }
    }

    IEnumerator CloseDoor()     //�� �ݱ�
    {
        while (true)
        {
            if (curDoor.left.localPosition.x <= 0.25)
            {
                Vector3 lpos = curDoor.left.localPosition;   //����
                lpos.x = 0.25f;
                curDoor.left.localPosition = lpos;

                Vector3 rpos = curDoor.right.localPosition;     //������
                rpos.x = -0.25f;
                curDoor.right.localPosition = rpos;

                break;
            }
            curDoor.left.Translate(new Vector3(-0.01f, 0, 0));
            curDoor.right.Translate(new Vector3(0.01f, 0, 0));

            yield return new WaitForSeconds(Time.deltaTime * doorSpeed);
        }
    }

    IEnumerator CMove()     //�� �� �̵�
    {
        while (true)
        {
            Debug.Log(currentFloor);
            if (isUp)   //6���� �����ϸ� 1������ ��������
            {
                if (transform.localPosition.y >= floors[currentFloor].localPosition.y)
                {
                    Vector3 vec = transform.localPosition;
                    vec.y = floors[currentFloor].localPosition.y;
                    transform.localPosition = vec;
                    
                    break;
                }
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }

            else
            {
                if (transform.localPosition.y <= floors[currentFloor].localPosition.y)
                {
                    Vector3 vec = transform.localPosition;
                    vec.y = floors[currentFloor].localPosition.y;
                    transform.localPosition = vec;
                    
                    break;
                }
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);
        if(isUp)
        {
            currentFloor++;
            if (currentFloor > floors.Count - 1)
            {
                isUp = false;
                currentFloor--;               
            }
        }

        else
        {
            currentFloor--;
            if (currentFloor < 0)
            {
                isUp = true;
                currentFloor = 0;
                currentFloor++;
            }
        }
        StartCoroutine("MainEV");
    }
}
