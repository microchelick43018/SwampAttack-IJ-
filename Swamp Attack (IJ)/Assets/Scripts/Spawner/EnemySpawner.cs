using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Player _target;
    [SerializeField] private List<Transform> _spawnPoints;

    protected override void InitializeObject(GameObject prefab)
    {
        base.InitializeObject(prefab);
        prefab.GetComponent<Enemy>().Init(_target);
    }

    public Transform GetRandomSpawnPoint()
    {
        if (_spawnPoints.Count == 0)
        {
            return null;
        }
        int resultNumber = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[resultNumber];
    }

    public void SpawnPrefab(GameObject prefab, Vector3 position)
    {
        prefab.SetActive(true);
        prefab.transform.position = position;
    }
}