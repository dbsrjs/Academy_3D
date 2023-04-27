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
            if(fDoor.left.localPosition.z >= 0.75)
            {
                Vector3 lpos = fDoor.left.position;
                lpos.z = 0.75f;
                fDoor.left.position = lpos;

                Vector3 rpos = fDoor.left.position;
                rpos.z = -0.75f;
                fDoor.left.position = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(0, 0, 0.01f));
            fDoor.right.Translate(new Vector3(0, 0, -0.01f));

            yield return new WaitForSeconds(Time.deltaTime * 10f);
        }

        yield return new WaitForSeconds(3f);

        while (true)
        {
            if (fDoor.left.localPosition.z <= 0.25)
            {
                Vector3 lpos = fDoor.left.position;
                lpos.z = 0.25f;
                fDoor.left.position = lpos;

                Vector3 rpos = fDoor.left.position;
                rpos.z = -0.25f;
                fDoor.left.position = rpos;

                break;
            }
            fDoor.left.Translate(new Vector3(0, 0, -0.01f));
            fDoor.right.Translate(new Vector3(0, 0, 0.01f));

            yield return new WaitForSeconds(Time.deltaTime * 10f);
        }

        yield return null;
    }
}
