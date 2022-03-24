using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ArrowAim : MonoBehaviour
{

    private AimingPanel _geodeUiAimingPanel;

    void Awake()
    {
        _geodeUiAimingPanel = GetComponentInParent<AimingPanel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       

        Vector3 posTarget = _geodeUiAimingPanel.transform.position;
        posTarget.z = 0f;
        transform.LookAt(posTarget);

    }

}
