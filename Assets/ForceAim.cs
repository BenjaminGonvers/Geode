using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAim : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private ChargingBar _chargingBar; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y == 0 && transform.localPosition.x == 0)
        {
            GetComponentInChildren<Renderer>().enabled = false;

            _chargingBar.GetComponent<Renderer>().enabled = false;

        }
        else
        {
            GetComponentInChildren<Renderer>().enabled = true;
            _chargingBar.GetComponent<Renderer>().enabled = true;

            float newAngle = 0;
            Vector3 relative = transform.InverseTransformPoint(_playerTransform.position);
            newAngle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -newAngle + 90);
        }

    }

}
