using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHael : HeartPool
{
    [SerializeField] private HeartMovement m_Movement;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _timeSpawn;
 
    private int _randomPosition;

    private void Start()
    {
        StartCoroutine(AppearIn());
        Initialized(m_Movement);
    }

    private void SetEnemy(HeartMovement hael, Vector3 spawnPoint)
    {
        hael.gameObject.SetActive(true);
        hael.transform.position = spawnPoint;
    }

    private IEnumerator AppearIn()
    {
        var waitForOneSeconds = new WaitForSeconds(_timeSpawn);

        while (enabled)
        {
            _randomPosition = Random.Range(0, _spawnPoint.Length);

            HeartMovement hael;

            if (TryGetObject(out hael))
            {
                SetEnemy(hael, _spawnPoint[_randomPosition].transform.position);
            }

            yield return waitForOneSeconds;
        }
    }
}
