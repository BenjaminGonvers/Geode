using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    //Vector3 nextPos;
    private float position; // between 0 and 1
    private bool isGoingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position == pos1.position)
        //{
        //    nextPos = pos2.position;
        //}

        //if (transform.position == pos2.position)
        //{
        //    nextPos = pos1.position;
        //}

        if (isGoingRight)
            position += speed * Time.deltaTime;
        else
            position -= speed * Time.deltaTime;

        if (position >= 1)
        {
            position = 1;
            isGoingRight = false;
        }
        else if (position <= 0)
        {
            position = 0;
            isGoingRight = true;
        }

        //transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(pos1.position, pos2.position, position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
