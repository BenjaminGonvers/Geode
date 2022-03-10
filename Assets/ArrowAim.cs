using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimingArrow(Vector2 posAim)
    {
        posAim = posAim.normalized * 5F;
        this.transform.position.Set(posAim.x*-5f,posAim.y*-5f,0f);
    }
}
