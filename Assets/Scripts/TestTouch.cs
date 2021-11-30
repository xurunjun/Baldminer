using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{

    private InputManager inputManager;
    private Camera cameraMain;

    private void Awake() {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }
    private void OnEnable() {
        inputManager.onEndTouch+=Move;
    }

    private void OnDisable() {
        inputManager.onEndTouch -=Move;
    }

    public void Move(Vector2 screenPosition,float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x,screenPosition.y,cameraMain.nearClipPlane);
        Vector3 worldCoorinated= cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoorinated.z = -2;
        transform.position=worldCoorinated;
    }
}
