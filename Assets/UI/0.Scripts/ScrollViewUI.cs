using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewUI : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(prefab, parent);
        }
    }
}
