using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] int _maxHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <=0)
            _health = 0;

        HealthChanged?.Invoke(_health);

        if (_health <= 0)       
            Die();        
    }

    public void SertHalth(int heal)
    {
        _health += heal;
        if(_health > _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        Debug.Log("Умер Игрок!");
        Died?.Invoke();      
    }
}