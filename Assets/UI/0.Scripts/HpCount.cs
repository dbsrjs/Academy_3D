using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCount : MonoBehaviour
{
    [System.Serializable]
    public struct MyVal
    {
        public Image img;
        public float val;
        public float maxval;
        public float autoval;
        public float autovaldelay;
    }
    public MyVal[] myVals;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            myVals[0].val -= 10;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            myVals[1].val -= 5;
        }

        SetValue(myVals[0].img, ref myVals[0].val, myVals[0].maxval, 10f);
        SetValue(myVals[1].img, ref myVals[1].val, myVals[1].maxval, 5f);
    }
    void SetValue(Image img,ref float cur, float max, float speed)
    {
        cur += Time.deltaTime * speed;
        if (cur >= max)
        {
            cur = max;
        }
        img.fillAmount = cur / max;
    }
}
