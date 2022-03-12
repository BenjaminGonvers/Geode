using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TellToUI : MonoBehaviour
{
    [SerializeField] private ArrowAim _arrowAim;

    // Start is called before the first frame update
    void Start()
    {
        if (_arrowAim == null)
        {
            Debug.LogError("ArrowAim need to be no null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimingUI(InputAction.CallbackContext context)
    {
        Vector2 posAim = context.ReadValue<Vector2>().normalized;
        

        _arrowAim.transform.position = (this.transform.position + new Vector3(posAim.x *-1F, posAim.y*-1F, 0));
        
    }
}
