using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PaddleController : MonoBehaviour
{
    [SerializeField] private int worldUnits;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    public PaddleController()
    {
        minX = -7.2f;
        maxX = 7.2f;
        worldUnits = 4;
    }
    

    private void Start()
    {
        Camera cam = Camera.main;
        Mouse.current.WarpCursorPosition(cam.WorldToScreenPoint(gameObject.transform.position));
    }

    private void Update()
    {
        // Move our paddle to our mouse's position.
        float mousePositionX = Input.mousePosition.x;
        
        float clampedPosX = Mathf.Clamp((mousePositionX / Screen.width) * worldUnits, minX, maxX);
        gameObject.transform.position = new Vector2(clampedPosX - 2, -7.04f);
    }

   
}
