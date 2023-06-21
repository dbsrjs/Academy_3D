using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game5Cont : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] Game_Player p;
    [SerializeField] private AudioSource audiosos;
    [SerializeField] private GameObject boss;

    string[] strs = { "무", "궁", "화", "꽃", "이", "피", "었", "습", "니", "다" };

    string curStr;
    int strIndex = 0;
    float curTimer;
    float strDelayTime = 0f;
    int waitTimer = 4;

    bool isStart = false;
    bool isStop = false;

    Vector3 PStopPos;
    // Start is called before the first frame update
    void Start()
    {
        WaitTime();
        InvokeRepeating("WaitTime", 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
            return;

        curTimer += Time.deltaTime;
        if (curTimer >= strDelayTime)
        {
            curTimer = 0;
            curStr = strs[strIndex];
            txt.text = curStr;
            strIndex++;

            if (strIndex > strs.Length)
            {
                strIndex = 0;
                strDelayTime = Random.Range(1f, 3f);
                isStop = true;
                PStopPos = p.transform.position;
            }
            else
            {
                strDelayTime = Random.Range(.05f, .5f);
                isStop = false;
            }
        }

        if (isStop)
        {

            if((int)PStopPos.z != (int)p.transform.position.z)
            {
                isStop = false;
                p.Dead();
                //AudioSource.Play();
            }
        }

        if (p.isFinish)
        {
            isStart = false;
            txt.text = $"통과";
        }
    }

    void WaitTime()
    {
        waitTimer--;
        txt.text = $"시작 대기 : {waitTimer}초 전...";

        if (waitTimer <= 0)
        {
            isStart = true;
            CancelInvoke();

            if (!p.isStart)
            {

            }
        }
    }

    void PlayerKill()
    {
        txt.text = $"실패";
        p.Dead();
        //AudioSource.Play();
    }
}
