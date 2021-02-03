using System;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] PaddleController paddle;
    [SerializeField] float launchXVelocity;
    [SerializeField] float launchYVelocity;

    /*private bool debounce = false;
    [SerializeField] Vector2 offset = new Vector2(0f, 1.2f);*/



    private Vector2 paddleToDiamond;
    private bool hasDiamondLaunched;


    private void Start()
    {
        paddleToDiamond = gameObject.transform.position - paddle.transform.position;
    }



    private void Update()
    {
        ClampVelocity(gameObject.GetComponent<Rigidbody2D>(), 25f);
        if (!hasDiamondLaunched)
        {
            LockDiamondToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            hasDiamondLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchXVelocity, launchYVelocity);
        }
    }

    private void LockDiamondToPaddle()
    {
        gameObject.transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleToDiamond;
    }

    private void ClampVelocity(Rigidbody2D rb, float maxVelocity)
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
