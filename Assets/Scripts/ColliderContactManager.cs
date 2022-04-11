using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContactManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);

            FindObjectOfType<AudioManager>().Play("StarSound");
        }
    }
}

