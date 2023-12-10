using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] private PlayerPicker _playerPicker;
    [SerializeField] private TMP_Text _bonusDisplay;

    private void OnEnable()
    {
       _playerPicker.BonusChanged += OnHealthCanged;
    }

    private void OnDisable()
    {
        _playerPicker.BonusChanged -= OnHealthCanged;
    }

    private void OnHealthCanged(int bonus)
    {
        _bonusDisplay.text = bonus.ToString();
    }
}