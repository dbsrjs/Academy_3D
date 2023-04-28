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

    
    void Start()
    {
        StartCoroutine(DoorAnimation());
    }

    void Update()
    {
        
    }
    IEnumerator DoorAnimation()
    {
        //������ Z ���� �����ش�.
        //�ʱⰪ�� 0.25 �ƽ� ���� 0.84
        yield return new WaitForSeconds(3f);

        while (true)
        {
            if(fDoor.left.localPosition.x >= 0.75)
            {
                Vector3 lpos = fDoor.left.position;
                lpos.x = 0.75f;
                fDoor.left.position = lpos;

                Vector3 rpos = fDoor.right.position;
                rpos.x = -0.75f;
                fDoor.right.position = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(0.01f, 0, 0));
            fDoor.right.Translate(new Vector3(-0.01f, 0, 0));

            yield return new WaitForSeconds(Time.deltaTime * 10f);
        }

        yield return new WaitForSeconds(3f);

        while (true)    //����
        {
            if (fDoor.left.localPosition.x <= 0.25)
            {
                Vector3 lpos = fDoor.left.position;
                lpos.x = 0.25f;
                fDoor.left.position = lpos;

                Vector3 rpos = fDoor.right.position;
                rpos.x = -0.25f;
                fDoor.right.position = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(-0.01f, 0, 0));
            fDoor.right.Translate(new Vector3(0.01f, 0, 0));

            yield return new WaitForSeconds(Time.deltaTime * 10f);
        }

        yield return null;
    }
}
