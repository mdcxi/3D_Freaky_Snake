using System;
using Cysharp.Threading.Tasks;
using Lean.Pool;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FreakySnake.Enemies
{
    [DefaultExecutionOrder(999)]
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
    
        [Space(2)]
        [Header("Waves Config")]
        [SerializeField] private int maxWaves = 2;
        [SerializeField] private float timeBetweenWaves = 3f;
        [SerializeField] private int enemiesPerWave = 5;
        [SerializeField] private float spawningDelayTime = 1;

        [Space(2)]
        [Header("Waves Display Config")]
        [SerializeField] private TextMeshProUGUI wavesText;
        
        [Space(2)]
        [SerializeField] private Transform[] spawnPoints;
        
        private int _currentWave = 1;

        private void Awake()
        {
            SpawnWaves().Forget();
        }
        
        private void Update()
        {
            SetWaveValuesDisplay();
        }

        private void SetWaveValuesDisplay()
        {
            wavesText.text = String.Format("Wave {0}/{1}", _currentWave,
                maxWaves);
        }

        private void SpawnEnemies()
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            var point = spawnPoints[spawnPointIndex];
            
            LeanPool.Spawn(enemyPrefab, point.position, point.rotation);
        }

        private async UniTask SpawnWaves()
        {
            while (_currentWave < maxWaves)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    SpawnEnemies();
                    await UniTask.Delay(TimeSpan.FromSeconds(spawningDelayTime));
                }

                _currentWave++;
                
                await UniTask.Delay(TimeSpan.FromSeconds(timeBetweenWaves));
            }
        }
    }
}
