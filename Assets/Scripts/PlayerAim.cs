using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerAiming(InputAction.CallbackContext context)
    {
       Vector2 posAim = context.ReadValue<Vector2>();


        transform.localPosition = new Vector3(posAim.x * -2f, posAim.y *-2f, 0f);


    }

}
