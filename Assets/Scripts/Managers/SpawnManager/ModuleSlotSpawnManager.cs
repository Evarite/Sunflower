using Sunflower.ModuleSlot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Managers.Spawn
{
    [AddComponentMenu("Sunflower/Modules/Slot Spawn Manager")]
    public class SlotManager : MonoBehaviour
    {
        [SerializeField] private SpawnManagerData _data;



        private float _currentHeight = 0f;

        private float _minSpawnValue;
        private float _maxSpawnValue;

        public IReadOnlyList<Slot> AllSlots => _data.AllSlots;

        private void Awake()
        {
            _minSpawnValue = -_data.SpawnDistanceMagnitude;
            _minSpawnValue = _data.SpawnDistanceMagnitude;
        }

        private void OnEnable() => StartCoroutine(SpawnSlots());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator SpawnSlots()
        {
            while (true)
            {
                float targetHeight = _currentHeight + _data.SpawnInterval;

                yield return new WaitUntil(() => _data.SunflowerGrowth.Height >= targetHeight);

                int count = Random.Range(_data.MinSpawnCount, _data.MaxSpawnCount);

                for (int i = 0; i < count; i++)
                {
                    float x = Random.Range(_minSpawnValue, _maxSpawnValue);
                    float y = Random.Range(_minSpawnValue, _maxSpawnValue);

                    Vector3 spawnPos = new Vector2(x, y);
                    spawnPos = Vector3.ClampMagnitude(spawnPos, _data.SpawnDistanceMagnitude);
                    spawnPos.y += _currentHeight;

                    Instantiate(_data.SlotPrefab, spawnPos, Quaternion.identity);
                }

                float randVal = Random.Range(0f, 1f);
                if (randVal <= _data.EnvSlotChance)
                {
                    Instantiate(_data.EnvSlotPrefab, new Vector2(_data.EnvSlotX, _currentHeight),
                        Quaternion.identity);
                }

                _currentHeight += _data.SpawnInterval;
            }
        }
    }
}