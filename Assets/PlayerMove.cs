using System.Collections;
using System.Collections.Generic;using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]private float _maxForcePut;

    private Vector2 _posAim = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void InAim(InputAction.CallbackContext context)
    {
        _posAim = context.ReadValue<Vector2>();
    }

    public void LaunchGeode(InputAction.CallbackContext context)
    {

        Vector2 impulseForce = _posAim * _maxForcePut * -1f;

        GetComponent<Rigidbody2D>().AddForce(impulseForce,ForceMode2D.Impulse);
    }
}
