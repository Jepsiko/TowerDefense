using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves;

    public Wave[] waves;

    public Transform[] path;

    private bool _spawningWave;
    private int _currentWaveIndex;
    private GameController _controller;

    private void Start()
    {
        _controller = GetComponent<GameController>();
        _currentWaveIndex = 0;
    }

    private void Update()
    {
        if (!_spawningWave && _controller.enemies.childCount == 0 && _currentWaveIndex < waves.Length)
        {
            _spawningWave = true;
            StartCoroutine(SpawnWave());
        }
    }

    public IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        foreach (var batch in waves[_currentWaveIndex].batches) 
        {
            for (int i = 0; i < batch.size; i++)
            {
                SpawnEnemy(batch.enemy);
                yield return new WaitForSeconds(batch.interval);
            }
        }
        _currentWaveIndex++;
        _spawningWave = false;
    }

    public void SpawnEnemy(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab, _controller.enemies.position, Quaternion.identity, _controller.enemies);
        enemy.GetComponent<MoveAlongPath>().waypoints = path;
    }
}
