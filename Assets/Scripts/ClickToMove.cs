using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class ClickToMove : MonoBehaviour
{
    [SerializeField] private InputAction mouseClickAction;

    private void OnEnable()
    {
        mouseClickAction.Enable();
        mouseClickAction.performed += Move;
    }

    private void OnDisable()
    {
        mouseClickAction.Disable();
        mouseClickAction.performed -= Move;
    }
    private void Move(InputAction.CallbackContext context)
    {
        
    }
}
