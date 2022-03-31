using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerPhysiqueBehavior : MonoBehaviour
{
    [Tooltip("This value represent the factor of slows down on ALL surface, tha base value is 1")]
    [SerializeField] private float _frictionalFactor = 1;
  
    

    private Rigidbody2D _myRigidbody2D;
    private float _actualFrictional = 0;


    [SerializeField]  private int _collidingGround = 0;


    

    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myRigidbody2D.velocity.x <= 0.1f && _myRigidbody2D.velocity.x >= -0.1f)
        {
            _myRigidbody2D.velocity.Set(0f, _myRigidbody2D.velocity.y);
            _myRigidbody2D.angularVelocity = 0f;
        }

        if (_collidingGround != 0)
        {

            _myRigidbody2D.angularDrag = _actualFrictional;
            
        }
        else
        {
            _myRigidbody2D.angularDrag = 0f;
        }
    }


    //Just hit another collider 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.otherCollider == null)
        {
            return;
        }

        _collidingGround++;

        _actualFrictional = collision.otherCollider.friction * _frictionalFactor * 20f;

    }

    //Hitting a collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Do something 
    }

    //Just stop hitting a collider 2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider == null)
        {
            return;
        }

        _collidingGround--;

        
        }
    }

