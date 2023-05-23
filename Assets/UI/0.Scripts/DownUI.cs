using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DownUI : MonoBehaviour
{
    TMP_Dropdown dd;
    // Start is called before the first frame update
    void Start()
    {
        dd = GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        dd.options.Clear();

        List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < 6; i++)
        {
            TMP_Dropdown.OptionData od = new TMP_Dropdown.OptionData();
            od.text = i.ToString();
            data.Add(od);
        }

        dd.options = data;
    }
}
