using System.Collections;
using System.Collections.Generic;using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]private float _maxForcePut;

    private Vector2 _posAim = new Vector2(0f, 0f);
    private Vector2 _normalizedAim = new Vector2(0f, 0f);

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
        if (_posAim.y != 0 || _posAim.x != 0)
        {
            _normalizedAim = _posAim.normalized;
        }
        else
        {
            _normalizedAim = new Vector2(0f, 0f);
        }
    }

    public void LaunchGeode(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 impulseForce = _normalizedAim * _maxForcePut * -1f;

            GetComponent<Rigidbody2D>().AddForce(impulseForce, ForceMode2D.Impulse);
        }
    }
}
