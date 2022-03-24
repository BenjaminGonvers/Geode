using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingPanel : MonoBehaviour
{
    [Tooltip("The Transform of the player for the UI can follow him")]
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private Transform _playerTarget;


    private Camera _camera;
    private RectTransform _myRectTransform;

    


    void Awake()
    {
        _myRectTransform = GetComponent<RectTransform>();
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRectTransform = GetComponent<RectTransform>();
        _camera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerScreenPosition = _camera.WorldToScreenPoint(_playerTransform.position);
        _myRectTransform.SetPositionAndRotation(playerScreenPosition, Quaternion.identity);

        if (_playerTarget != null)
        {
            Vector3 playerTargetPosition = _camera.WorldToScreenPoint(_playerTarget.position);
            float angle = Mathf.Atan2(playerScreenPosition.y - playerTargetPosition.y,
                playerScreenPosition.x - playerTargetPosition.x);

            _myRectTransform.eulerAngles = new Vector3(0f, 0f, 90f + angle * Mathf.Rad2Deg);
        }
    }

  
}   