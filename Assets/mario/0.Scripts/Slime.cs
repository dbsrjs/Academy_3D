using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    Direction dir = Direction.Left;
    void Update()
    {
        LeftRay();
        RightRay();

        if (dir == Direction.Left)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3f);
        }
        else if (dir == Direction.Right)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3f);
        }
    }

    void LeftRay()
    {
        Vector3 leftPos = transform.position;
        leftPos.x -= 0.5f;
        leftPos.y -= 0.2f;
        Debug.DrawRay(leftPos, Vector3.down * 0.4f, Color.red);
                
        if(!Physics.Raycast(leftPos, Vector3.down, 0.4f))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, -0.5f);
            dir = Direction.Right;
        }
    }

    void RightRay()
    {
        Vector3 rightPos = transform.position;
        rightPos.x += 0.5f;
        rightPos.y -= 0.2f;
        Debug.DrawRay(rightPos, Vector3.down * 0.4f, Color.red);

        if (!Physics.Raycast(rightPos, Vector3.down, 0.4f))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            dir = Direction.Left;
        }
    }
}
