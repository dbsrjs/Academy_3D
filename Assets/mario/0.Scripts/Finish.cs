using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void SceneChange()
    {
        Scene s = SceneManager.GetActiveScene();
        switch (s.name)
        {
            case "Mario-1":
                SceneManager.LoadScene("Mario-2");
                break;
            case "Mario-2":
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SceneChange();
    }
}
