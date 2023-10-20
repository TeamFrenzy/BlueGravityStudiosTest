using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCInteractController : MonoBehaviour
{
    [SerializeField] internal MCController mcController;

    Rigidbody2D rb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    Character character;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 position = rb.position + mcController.lastMotionVector * offsetDistance;
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(2f,2f), 90f);

        foreach (Collider2D collider in colliders)
        {
            Interactable hit = collider.GetComponent<Interactable>();
            if(hit != null)
            {
                Debug.Log(collider.gameObject.name);
                hit.Interact(character, collider.gameObject);
                break;
            }
        }
    }
}
