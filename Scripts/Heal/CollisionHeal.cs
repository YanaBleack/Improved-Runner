using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    [SerializeField] private int _collisionHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.SertHalth(_collisionHeal);
        }
        Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
