using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisiomHeal : MonoBehaviour
{
    [SerializeField] private int _collisionBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerPicker playerPicker))
        {
            playerPicker.TakeBonus(_collisionBonus);
        }
        Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}