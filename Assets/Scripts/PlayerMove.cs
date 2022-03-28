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

    


    // Start is called before the first frame update
    void Start()
    {
        
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


        if (GetComponent<Rigidbody2D>().angularVelocity <= 10f && GetComponent<Rigidbody2D>().angularVelocity != 0f )
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
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
        if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
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

             setVelocityGeode(impulseForce);

             Charge = 0f;

            

         }
        }
        
    }

    private void PropulseGeode(Vector2 impulseForce)
    {

        GetComponent<Rigidbody2D>().AddForce(impulseForce, ForceMode2D.Impulse);
    }

    private void setVelocityGeode(Vector2 newVelocity)
    {
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }

}
