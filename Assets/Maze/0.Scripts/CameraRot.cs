using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    public float turnSpeed = 4.0f;  //���콺 ȸ�� ����
    private float xRotate = 0.0f;   //�� ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ����)

    // Update is called once per frame
    void Update()
    {
        //  �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        //  ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float tRotate = transform.eulerAngles.y + yRotateSize;

        //  ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        //  ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ����(-45:�ϴù���, 80:�ٴڹ���)
        //  Clamp�� ���� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        //  ī�޶� ȸ������ ī�޶� �ݿ�(x, y�ุ ȸ��)
        transform.eulerAngles = new Vector3(xRotate, yRotateSize, 0);
    }
}
