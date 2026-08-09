using UnityEngine;

namespace Sunflower.Modules.Components
{
    [CreateAssetMenu(fileName = "New Component", menuName = "Sunflower/Modules Components/Spawner Component")]
    public class SpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private float _spawnInterval = 5f;
        [SerializeField] private int _maxSpawned = 3;

        private float _spawnTimer;
        private int _spawnedCount;

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer > 0f)
                return;

            _spawnTimer = _spawnInterval;

            if (_spawnedCount >= _maxSpawned)
                return;

            Spawn();
        }

        private void Spawn()
        {
            GameObject spawned = Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
            _spawnedCount++;

            // подписаться на смерть заспавненного юнита
            // чтобы уменьшать _spawnedCount
        }
    }
}