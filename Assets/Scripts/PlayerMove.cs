using System.Collections;
using System.Collections.Generic;using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private ChargingBar _chargingBar;

    [SerializeField]private float _maxForcePut;
    [SerializeField] private float _maxForceDoubleJump;


    private Vector2 _posAim = new Vector2(0f, 0f);
    private Vector2 _normalizedAim = new Vector2(0f, 0f);

    private bool _isCharging = false;
    private float _charge = 0;

    private bool _alreadyDoubleJump = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCharging && _charge < 100)
        {
            _charge += 100f * Time.deltaTime;

            if (_charge > 100)
            {
                _charge = 100f;
            }
        }

        _chargingBar.transform.localScale = new Vector3(_charge / 100, 1, 1);

       
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

             if (_charge < 20f)
             {
                    _charge = 20f;
             }

             Vector2 impulseForce = _normalizedAim * _maxForcePut * -1f * _charge / 100f;

             setVelocityGeode(impulseForce);

             _charge = 0f;

             _alreadyDoubleJump = false;

         }
        }
        else
        {
            //if (!_alreadyDoubleJump && context.started)
            //{
            //    Vector2 impulseForce = _normalizedAim * _maxForceDoubleJump * -1f;
            //    setVelocityGeode(impulseForce);
            //    _alreadyDoubleJump = true;
            //}
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
