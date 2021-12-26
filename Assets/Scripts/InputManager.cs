using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[Serializable]
public class TouchEvent : UnityEvent<Vector2> { }
[Serializable]
<<<<<<< HEAD
public class HoldEndTouch : UnityEvent<Vector2, float> { }
=======
public class HoldEndTouch : UnityEvent<Vector2,float> { }
>>>>>>> remotes/origin/Pushfct
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public UnityEvent onHoldStartTouch;
    public UnityEvent onHoldPerformTouch;
    public HoldEndTouch onHoldEndTouch;
    public TouchEvent onEndTouch;
    private InputAction touchPosition;

<<<<<<< HEAD
    private Touchscreen touchscreen;

    private void Awake()
    {
        touchPosition = gameObject.GetComponent<PlayerInput>().currentActionMap.FindAction("TouchPosition");
        touchscreen = Touchscreen.current;
    }

    public void EndTouch(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Canceled)
=======
    private void Awake()
    {
        touchPosition = gameObject.GetComponent<PlayerInput>().currentActionMap.FindAction("TouchPosition");
    }

    public void EndTouch(InputAction.CallbackContext context)
    {

        if (context.performed)
>>>>>>> remotes/origin/Pushfct
        {
            onEndTouch.Invoke(touchPosition.ReadValue<Vector2>());
            // Debug.Log("end");
        }
    }

    public void HoldTouch(InputAction.CallbackContext context)
    {
<<<<<<< HEAD
        switch (context.phase)
        {
            case InputActionPhase.Started:
                onHoldStartTouch.Invoke();
                break;
            case InputActionPhase.Performed:
                onHoldPerformTouch.Invoke();
                break;
            case InputActionPhase.Canceled:
                onHoldEndTouch.Invoke(touchPosition.ReadValue<Vector2>(), (float)context.duration);
                break;
            // case InputActionPhase.Waiting:
            //     onHoldEndTouch.Invoke(touchPosition.ReadValue<Vector2>(), (float)context.duration);
            //     break;
            // case InputActionPhase.Disabled:
            //     onHoldEndTouch.Invoke(touchPosition.ReadValue<Vector2>(), (float)context.duration);
            //     break;
=======
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
>>>>>>> remotes/origin/Pushfct
        }
    }
}
