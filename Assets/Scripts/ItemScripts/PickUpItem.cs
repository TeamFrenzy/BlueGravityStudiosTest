using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.Instance.playerCharacter.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
            );
        if(distance < 0.1f)
        {
            if (GameManager.Instance.inventaryContainer != null)
            {
                GameManager.Instance.inventaryContainer.Add(item, count);
            }
            Destroy(gameObject);
        }
    }

}
