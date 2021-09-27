using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _currentWaveNumber = -1;
    private int _enemiesSpawned;
    private float _pastTime = 0;

    public event UnityAction AllEnemiesSpawned;

    private void Start()
    {
        SetNextWave();
    }

    private bool TryUpdateWave()
    {
        if (_enemiesSpawned == _currentWave.Count)
        {
            if (_currentWaveNumber + 1 < _waves.Count)
                AllEnemiesSpawned?.Invoke();

            _currentWave = null;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _pastTime += Time.deltaTime;

        if (_pastTime >= _currentWave.Delay)
        {
            if (_currentWave.Pool.TryGetObject(out GameObject enemyToSpawn))
            {
                _currentWave.Pool.SpawnPrefab(enemyToSpawn, _currentWave.Pool.GetRandomSpawnPoint().position);
                _enemiesSpawned++;
                TryUpdateWave();
                _pastTime = 0;
            }
        }
    }

    public void SetNextWave()
    {
        _enemiesSpawned = 0;
        if (_waves.Count > _currentWaveNumber)
        {
            _currentWave = _waves[++_currentWaveNumber];
        }
        else
        {
            _currentWave = null;
        }    
    }
}

[System.Serializable]
public class Wave
{
    public EnemySpawner Pool;
    public float Delay;
    public int Count;
};
