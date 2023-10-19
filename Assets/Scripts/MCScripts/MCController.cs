using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MCController : MonoBehaviour
{
    [SerializeField] internal MCAnimator mcAnimator;
    [SerializeField] float movementSpeed;

    private Rigidbody2D rb;

    public float horizontalMovement;
    public float verticalMovement;

    public Vector2 motionVector;
    public Vector2 lastMotionVector;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            Move();
        }
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            lastMotionVector = new Vector2(horizontalMovement, verticalMovement).normalized;
        }
    }

    private void Move()
    {
        rb.velocity = motionVector * movementSpeed;
    }
}
