using Sunflower.Growth;
using Sunflower.Utilities.WeightedRandom;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemiesSpawnManager : MonoBehaviour
    {
        public static EnemiesSpawnManager Instance { get; private set; }

        [SerializeField] private SunflowerGrowth _growth;

        [SerializeField] private WeightedRandomList<GameObject> _enemies;

        [SerializeField] private float _spawnDistance = 10f;

        [SerializeField] private float _startSpawnHeight = 10f;

        private List<GameObject> _activeEnemies = new();

        public List<GameObject> ActiveEnemies => _activeEnemies;

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Update()
        {
            if (_growth.Height < _startSpawnHeight)
                return;

            var enemy = _enemies.GetRandomItem();
            if (enemy == null)
                return;

            Vector2 spawn = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            spawn = spawn.normalized * _spawnDistance;

            var spawnedEnemy =
                Instantiate(enemy, new Vector2(0, _growth.Height) + spawn, Quaternion.identity);

            _activeEnemies.Add(spawnedEnemy);
        }
    }
}