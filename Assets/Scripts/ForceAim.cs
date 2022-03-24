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
        //see if we need to display(if no direction from the player, we don't display the charging bar)
        if (_playerTransform.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            GetComponentInChildren<Renderer>().enabled = false;
            _chargingBar.GetComponent<Renderer>().enabled = false;

        }
        else
        {

            GetComponentInChildren<Renderer>().enabled = true;
            _chargingBar.GetComponent<Renderer>().enabled = true;

            //calculate the Z axis for the rotational position and setting it
            float newAngle = 0;
            Vector3 relative = transform.InverseTransformPoint(_playerTransform.position);
            newAngle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -newAngle + 90);

        }

        Vector3 newPos = _playerTransform.position;
        newPos.z = 0.0f;
        transform.LookAt(newPos);
    }

}
