using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    [SerializeField] private Vector3Event onMouseClicked;

    private bool locked = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !locked)
        {
            locked = true;
            onMouseClicked.Raise(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && locked)
        {
            locked = false;
        }
    }
    
    
}
