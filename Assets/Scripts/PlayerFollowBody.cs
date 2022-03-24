using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowBody : MonoBehaviour
{

    [SerializeField] private Transform _playerBodyTransform;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = _playerBodyTransform.position;

    }

}
