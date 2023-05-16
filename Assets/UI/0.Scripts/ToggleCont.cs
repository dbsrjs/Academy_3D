using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCont : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] GameObject[] toggleobjs;

    // Start is called before the first frame update
    void Start()
    {
        SetFontColorChange();
        for (int i = 0; true; i++)
        {
            Debug.Log("d¤·");
        }
    }

    public void OnValueChange(Toggle toggle)
    {
        SetFontColorChange();

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn)
            {
                toggleobjs[i].SetActive(true);
            }
            else
            {
                toggleobjs[i].SetActive(false);
            }
                        
        }        
    }

    void SetFontColorChange()
    {
        foreach (var item in toggles)
        {
            if (item.isOn)
            {
                item.transform.GetChild(0).transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.red;
            }
            else
            {
                item.transform.GetChild(0).transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = Color.black;
            }
        }
    }
}
