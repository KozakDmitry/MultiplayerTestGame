using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Transform cam;
    
    public void SetCamera(Transform camera)
    {
        cam = camera;
    }

    private void LateUpdate()
    {
        if (cam != null) 
        {
            transform.LookAt(cam.position);
        }
    }

}
