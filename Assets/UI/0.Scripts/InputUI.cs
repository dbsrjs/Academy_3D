using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class InputUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField idField;
    [SerializeField] private TMP_InputField psField;

    string id = "dbs";
    string ps = "aaa";

    public void OnValueChangeID()
    {

    }

    public void OnValueChangeePS()
    {

    }

    public void OnSend()
    {
        if (!isIDCheck())
        {
            Debug.Log("ID�� ��ġ���� �ʽ��ϴ�.");
            return;
        }

        if (!isPSCheck())
        {
            Debug.Log("��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
            return;
        }
        Debug.Log("����");
    }

    bool isIDCheck()
    {
        if (idField.text == id)
            return true;
        return false;
    }

    bool isPSCheck()
    {
        if (idField.text == ps)
            return true;
        return false;
    }
}
