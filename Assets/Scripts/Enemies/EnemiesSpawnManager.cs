using Sunflower.Growth;
using Sunflower.Utilities.WeightedRandom;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemiesSpawnManager : MonoBehaviour
    {
        [SerializeField] private SunflowerGrowth _growth;

        [SerializeField] private WeightedRandomList<GameObject> _enemies;

        [SerializeField] private float _spawnDistance = 10f;

        private void Update()
        {
            var enemy = _enemies.GetRandomItem();
            if (enemy == null)
                return;

            Vector2 spawn = new Vector2(Random.Range(-1, 1), Random.Range(0, 1));
            spawn = spawn.normalized * _spawnDistance;

            Instantiate(enemy, new Vector2(0, _growth.Height) + spawn, Quaternion.identity);
        }
    }
}