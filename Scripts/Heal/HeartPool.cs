using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    [SerializeField] private HeartMovement _container;
    [SerializeField] private int _capacity;

    private List<HeartMovement> _pool = new List<HeartMovement>();

    protected void Initialized(HeartMovement prefabHeal)
    {
        for (int i = 0; i < _capacity; i++)
        {
            HeartMovement spawned = Instantiate(prefabHeal, _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out HeartMovement result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}