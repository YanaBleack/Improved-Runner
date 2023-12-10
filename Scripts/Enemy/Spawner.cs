using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private EnemyMovement[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private Vector2 _direction;

    private int _random;
    private int _randomPosition;

    private void Start()
    {
        StartCoroutine(AppearIn());
        Initialize(_enemyTemplates);
    }

    private void SetEnemy(EnemyMovement enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator AppearIn()
    {
        var waitForOneSeconds = new WaitForSeconds(_timeSpawn);

        while (enabled)
        {
            _random = Random.Range(0, _enemyTemplates.Length);
            _randomPosition = Random.Range(0, _spawnPoint.Length);

            EnemyMovement enemy;

            if (TryGetObject(out enemy))
            {
                SetEnemy(enemy, _spawnPoint[_randomPosition].transform.position);
                enemy.SetDirection(_direction);
            }

            yield return waitForOneSeconds;
        }
    }
}