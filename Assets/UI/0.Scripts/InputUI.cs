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
            Debug.Log("ID가 일치하지 않습니다.");
            return;
        }

        if (!isPSCheck())
        {
            Debug.Log("비밀번호가 일치하지 않습니다.");
            return;
        }
        Debug.Log("성공");
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
