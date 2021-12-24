using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class TouchEvent : UnityEvent<Vector2, InputAction.CallbackContext> { }
[Serializable]
public class HoldEndTouch : UnityEvent<Vector2,float> { }
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public UnityEvent onHoldStartTouch;
    public UnityEvent onHoldPerformTouch;
    public HoldEndTouch onHoldEndTouch;
    public TouchEvent onEndTouch;
    private InputAction touchPosition;

    private void Awake()
    {
        touchPosition = gameObject.GetComponent<PlayerInput>().currentActionMap.FindAction("TouchPosition");
    }

    public void EndTouch(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            onEndTouch.Invoke(touchPosition.ReadValue<Vector2>(), context);
            // Debug.Log("end");
        }
    }

    public void HoldTouch(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            onHoldStartTouch.Invoke();
            // Debug.Log("start");
        }
        if(context.performed)
        {
            onHoldPerformTouch.Invoke();
            // Debug.Log("perform");
        }
        if(context.canceled)
        {
            onHoldEndTouch.Invoke(touchPosition.ReadValue<Vector2>(), (float)context.duration);
            // Debug.Log("cancel");
        }
    }
}
