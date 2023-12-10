using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : PoolBonus
{
    [SerializeField] private MovementBonus _movementBonus;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _timeSpawn;

    private int _randomPosition;

    private void Start()
    {
        StartCoroutine(AppearIn());
        Initialized(_movementBonus);
    }

    private void SetEnemy(MovementBonus bonus, Vector3 spawnPoint)
    {
        bonus.gameObject.SetActive(true);
        bonus.transform.position = spawnPoint;
    }

    private IEnumerator AppearIn()
    {
        var waitForOneSeconds = new WaitForSeconds(_timeSpawn);

        while (enabled)
        {
            _randomPosition = Random.Range(0, _spawnPoint.Length);

            MovementBonus bonus;

            if (TryGetObject(out bonus))
            {
                SetEnemy(bonus, _spawnPoint[_randomPosition].transform.position);
            }

            yield return waitForOneSeconds;
        }
    }
}