using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ArrowAim : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        if (transform.localPosition.y == 0 && transform.localPosition.x == 0)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;

            float newAngle = 0;
            Vector3 relative = transform.InverseTransformPoint(playerTransform.position);
            newAngle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0,0,-newAngle);
        }

    }

}
