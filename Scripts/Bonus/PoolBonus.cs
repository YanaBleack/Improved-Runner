using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolBonus : MonoBehaviour
{
    [SerializeField] private MovementBonus _container;
    [SerializeField] private int _capacity;

    private List<MovementBonus> _pool = new List<MovementBonus>();

    protected void Initialized(MovementBonus prefabBonus)
    {
        for (int i = 0; i < _capacity; i++)
        {
            MovementBonus spawned = Instantiate(prefabBonus, _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out MovementBonus result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}