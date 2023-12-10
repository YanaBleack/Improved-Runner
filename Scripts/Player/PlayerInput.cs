using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)))
        {
            _playerMovement.TryMoveUp();
        }
        if ((Input.GetKeyDown(KeyCode.S)))
        {
            _playerMovement.TryMoveDown();
        }     
    }
}