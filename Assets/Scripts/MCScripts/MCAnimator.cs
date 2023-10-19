using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnimator : MonoBehaviour
{
    [SerializeField] internal MCController mcController;

    private Animator characterAnimator;

    public bool isMoving;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        if (mcController.canMove)
        {
            horizontal = mcController.horizontalMovement;
            vertical = mcController.verticalMovement;
        }

        mcController.motionVector = new Vector2(horizontal, vertical);
        characterAnimator.SetFloat("Horizontal", horizontal);
        characterAnimator.SetFloat("Vertical", vertical);

        isMoving = horizontal != 0 || vertical != 0;
        characterAnimator.SetBool("isMoving", isMoving);

        if (horizontal != 0 || vertical != 0)
        {
            characterAnimator.SetFloat("LastHorizontal", horizontal);
            characterAnimator.SetFloat("LastVertical", vertical);
        }
    }
}
