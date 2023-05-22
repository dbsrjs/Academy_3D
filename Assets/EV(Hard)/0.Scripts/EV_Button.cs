using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EV_Button : MonoBehaviour
{
    enum DoorDirection  //enum
    {
        Left,
        Right
    }

    [SerializeField] Transform elevertor;
    [SerializeField] Transform[] doors;
    [SerializeField] Transform[] floors;
    [SerializeField] Button[] doorBtn;

    bool isMove = false;
    public void OnClick_Open()
    {
        StartCoroutine(Open(doors[0], DoorDirection.Left));     //코루틴 불러오기
        StartCoroutine(Open(doors[1], DoorDirection.Right));
    }

    public void OnClick_Close()
    {
        StartCoroutine(Close(doors[0], DoorDirection.Left));    //코루틴 불러오기
        StartCoroutine(Close(doors[1], DoorDirection.Right));
    }

    public void AutoDoor()
    {
        StartCoroutine("CAutoDoor");
    }
        
    IEnumerator CAutoDoor()     //문 여닫기(자동)
    {
        yield return new WaitForSeconds(1f);    //delay Time
        OnClick_Open();
        yield return new WaitForSeconds(1f);    //delay Time
        OnClick_Close();
    }
    float doorSpeed = 10;
    IEnumerator Open(Transform trans, DoorDirection dir)    //열기
    {
        //min : 0.25    max : 0.7

        while (true)
        {
            if (dir == DoorDirection.Left)
            {
                if (trans.localPosition.z >= 0.7f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, 0.7f);   //좌표값으로 이동
                    yield break;
                }
                trans.Translate(Vector3.forward * Time.deltaTime * doorSpeed);
            }

            else   //Doorirection.Right
            {
                if (trans.localPosition.z <= -0.7f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, -0.7f);
                    yield break;
                }
                trans.Translate(Vector3.back * Time.deltaTime * doorSpeed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Close(Transform trans, DoorDirection dir)   //닫기
    {
        //min : 0.25    max : 0.7

        while (true)
        {
            if (dir == DoorDirection.Left)
            {
                if (trans.localPosition.z <= 0.25f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, 0.25f);    ////좌표값으로 이동
                    doorBtn[0].interactable = true;
                    doorBtn[1].interactable = true;
                    isMove = false;
                    yield break;
                }
                trans.Translate(Vector3.back * Time.deltaTime * doorSpeed);
            }

            else    //Doorirection.Right
            {
                if (trans.localPosition.z >= -0.25f)
                {
                    trans.localPosition = new Vector3(-0.5f, 0.5f, -0.25f);
                    doorBtn[0].interactable = true;
                    doorBtn[1].interactable = true;
                    isMove = false;
                    yield break;
                }
                trans.Translate(Vector3.forward * Time.deltaTime * doorSpeed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    float currentFloorY = 1f;   //현재 Y좌표
    int prevFloorIndex = 0;     //이전 층
    int curFloorIndex = -1;     //다음 층
    public void OnButtonClick(int floor)
    {
        if (isMove == true)
            return;

        if (floor - 1 == curFloorIndex)
            return;

        doorBtn[0].interactable = false;
        doorBtn[1].interactable = false;

        isMove = true;

        curFloorIndex = floor;
        Vector3 vec3 = floors[floor - 1].localPosition;

        currentFloorY = vec3.y;
        Debug.Log(currentFloorY);
    }

    
    void Update()
    {
        if(curFloorIndex > prevFloorIndex)  //up
        {
            if (elevertor.localPosition.y >= currentFloorY)
            {
                prevFloorIndex = curFloorIndex;
                StopCoroutine("CAutoDoor");
                StartCoroutine("CAutoDoor");
                return;
            } 
            elevertor.Translate(Vector3.up * Time.deltaTime * 1f);
        }
        else if(curFloorIndex < prevFloorIndex) //down
        {
            if (elevertor.localPosition.y <= currentFloorY)
            {
                prevFloorIndex = curFloorIndex;
                StopCoroutine("CAutoDoor");
                StartCoroutine("CAutoDoor");
                return;
            }
            elevertor.Translate(Vector3.down * Time.deltaTime * 1f);
        }
    }
    
}
