using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    SpriteRenderer sr;
    public enum dir { up, left, down, right }
    public dir arrow;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (arrow)
        {
            case dir.up:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    sr.color = Color.white;
                }
                else
                {
                    sr.color = Color.black;
                }
                break;
            case dir.left:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    sr.color = Color.white;
                }
                else
                {
                    sr.color = Color.black;
                }
                break;
            case dir.down:
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    sr.color = Color.white;
                }
                else
                {
                    sr.color = Color.black;
                }
                break;
            case dir.right:
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    sr.color = Color.white;
                }
                else
                {
                    sr.color = Color.black;
                }
                break;
            default:
                break;
        }
    }
}
