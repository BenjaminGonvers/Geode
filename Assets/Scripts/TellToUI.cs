using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TellToUI : MonoBehaviour
{
    [SerializeField] private ArrowAim _arrowAim;
    [SerializeField] private playerCamera _playerCamera;

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
        Vector2 posAimNormalized = context.ReadValue<Vector2>().normalized;

        Vector2 posAim = context.ReadValue<Vector2>();

        _arrowAim.transform.position = (this.transform.position + new Vector3(posAimNormalized.x *-1F, posAimNormalized.y*-1F, 0));

        _playerCamera.transform.position = (this.transform.position + new Vector3(posAim.x * -3f, posAim.y * -3f, -10f));

    }
}
