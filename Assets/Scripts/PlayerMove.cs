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

    private bool _isCharging = false;
    public float Charge = 0;


    private Rigidbody2D _myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCharging && Charge < 100)
        {
            Charge += 100f * Time.deltaTime;

            if (Charge > 100)
            {
                Charge = 100f;
            }


        }

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
        if (_myRigidbody2D.velocity == Vector2.zero)
        {


         if (context.started)
         {
             _isCharging = true;
         }

         if (context.canceled && _isCharging)
         {
             _isCharging = false;

             if (Charge < 20f)
             {
                    Charge = 20f;
             }

             Vector2 impulseForce = _normalizedAim * _maxForcePut * -1f * Charge / 100f;

             //SetVelocityGeode(impulseForce);
             PropulseGeode(impulseForce);

             Charge = 0f;

            

         }
        }
        
    }

    private void PropulseGeode(Vector2 impulseForce)
    {

        _myRigidbody2D.AddForce(impulseForce, ForceMode2D.Impulse);
    }

    private void SetVelocityGeode(Vector2 newVelocity)
    {
        _myRigidbody2D.velocity = newVelocity;
    }

}
