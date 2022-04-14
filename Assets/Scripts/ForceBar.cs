using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private PauseMenu _pauseGame;

    private bool _playerIsAiming;
    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        if (_playerRigidbody2D.velocity == Vector2.zero&&_playerIsAiming && !_pauseGame.isGamePaused)
        {
            _image.enabled = true;
        }
        else
        {
            _image.enabled = false;
        }
    }

    public void GetAimBar(InputAction.CallbackContext context)
    {
        Vector2 _posAim = context.ReadValue<Vector2>();
        if (_posAim != Vector2.zero)
        {
            _playerIsAiming = true;
        }
        else
        {
            _playerIsAiming = false;
        }

    }
}
