using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameGrid))]
[RequireComponent(typeof(WaveSpawner))]
public class GameController : MonoBehaviour
{
    public Level level;

    public Transform grid;
    public Transform enemies;

    public BaseHealthUI baseHealthUI;

    private GameGrid _gameGrid;
    private WaveSpawner _waveSpawner;

    private void Start() {
        _gameGrid = GetComponent<GameGrid>();
        _gameGrid.GenerateGrid(level.map);

        Health baseHealth = _gameGrid.GetFinishTile().GetComponent<Health>();
        baseHealthUI.UpdateHealth(baseHealth.health, baseHealth.maxHealth);
        baseHealth.onDamageTaken.AddListener(baseHealthUI.UpdateHealth);
        baseHealth.onDeath.AddListener(GameOver);

        _waveSpawner = GetComponent<WaveSpawner>();
        _waveSpawner.path = _gameGrid.GetPath();
        _waveSpawner.waves = level.waves;
    }

    private void GameOver()
    {
        Debug.Log("Game Over !");
        _waveSpawner.enabled = false;
    }
}
