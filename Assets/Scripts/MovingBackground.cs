using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public Vector2 offset = new Vector2(0, 0);
    public float scrollSpeed = 1.0f;
    public void Update()
    {
        offset += new Vector2(Time.time * Input.GetAxis("Horizontal") * -1 * scrollSpeed, 0);
        //assign offset here
    }
}