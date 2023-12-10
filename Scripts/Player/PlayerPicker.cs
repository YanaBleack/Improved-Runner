using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPicker : MonoBehaviour
{
    private int _bonus;

    public event UnityAction<int> BonusChanged;

    public void TakeBonus(int bonus)
    {
        _bonus += bonus;

        BonusChanged?.Invoke(_bonus);
    }

    private void Start()
    {
        BonusChanged?.Invoke(_bonus);
    }
}