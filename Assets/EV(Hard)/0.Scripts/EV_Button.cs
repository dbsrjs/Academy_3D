using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EV_Button : MonoBehaviour
{
    enum DoorDirection  //enum
    {
        Left,
        Right
    }

    [SerializeField] Transform[] doors;
    [SerializeField] Transform[] floors;

    public void OnClick_Open()
    {
        StartCoroutine(Open(doors[0], DoorDirection.Left));     //�ڷ�ƾ �ҷ�����
        StartCoroutine(Open(doors[1], DoorDirection.Right));
    }

    public void OnClick_Close()
    {
        StartCoroutine(Close(doors[0], DoorDirection.Left));    //�ڷ�ƾ �ҷ�����
        StartCoroutine(Close(doors[1], DoorDirection.Right));
    }

    public void AutoDoor()
    {
        StartCoroutine("CAutoDoor");
    }
        
    IEnumerator CAutoDoor()     //�� ���ݱ�
    {
        OnClick_Open();
        yield return new WaitForSeconds(1f);    //delay Time
        OnClick_Close();
    }
    float doorSpeed = 10;
    IEnumerator Open(Transform trans, DoorDirection dir)
    {
        //min : 0.25    max : 0.7

        while (true)
        {
            if (dir == DoorDirection.Left)  
            {
                if (trans.localPosition.z <= 0.25f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, 0.7f);   //��ǥ������ �̵�
                    yield break;
                }
                trans.Translate(Vector3.left * Time.deltaTime * doorSpeed);
            }

            else   //Doorirection.Right
            {
                if (trans.localPosition.z >= -0.25f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, -0.7f);
                    yield break;
                }
                trans.Translate(Vector3.right * Time.deltaTime * doorSpeed);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Close(Transform trans, DoorDirection dir)
    {
        //min : 0.25    max : 0.7

        while (true)
        {
            if (dir == DoorDirection.Left)
            {
                if (trans.localPosition.z >= 0.7f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, 0.25f);    ////��ǥ������ �̵�
                    yield break;
                }
                trans.Translate(Vector3.left * Time.deltaTime * doorSpeed);
            }

            else
            {
                if (trans.localPosition.z <= 0.7f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, -0.25f);
                    yield break;
                }
                trans.Translate(Vector3.right * Time.deltaTime * doorSpeed);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
