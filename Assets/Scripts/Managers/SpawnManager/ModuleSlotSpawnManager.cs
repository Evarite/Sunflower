using Sunflower.ModuleSlot;
using Sunflower.SaveSystem.Data;
using System.Collections;
using UnityEngine;

namespace Sunflower.Managers.Spawn
{
    [AddComponentMenu("Sunflower/Modules/Slot Spawn Manager")]
    public class ModuleSlotSpawnManager : MonoBehaviour
    {
        [SerializeField] private SpawnManagerData _data;
        [SerializeField] private SlotsManager _slotsManager;

        private float _currentHeight;

        private float _minSpawnValue;
        private float _maxSpawnValue;

        public float CurrentHeight => _currentHeight;

        private void Awake()
        {
            _minSpawnValue =
                -_data.SpawnDistanceMagnitude;

            _maxSpawnValue =
                _data.SpawnDistanceMagnitude;
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnSlots());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator SpawnSlots()
        {
            while (true)
            {
                float targetHeight =
                    _currentHeight +
                    _data.SpawnInterval;

                yield return new WaitUntil(
                    () => _data.SunflowerGrowth.Height >=
                          targetHeight
                );

                int count = Random.Range(_data.MinSpawnCount, _data.MaxSpawnCount);

                for (int i = 0; i < count; i++)
                {
                    SpawnSlot(
                        GetRandomSpawnPosition(), SlotType.Stem
                    );
                }

                float randomValue =
                    Random.Range(0f, 1f);

                if (randomValue <= _data.EnvSlotChance)
                {
                    SpawnSlot(
                        new Vector2(
                            _data.EnvSlotX,
                            _currentHeight
                        ), SlotType.Environment
                    );
                }

                _currentHeight +=
                    _data.SpawnInterval;
            }
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float x = Random.Range(
                _minSpawnValue,
                _maxSpawnValue
            );

            float y = Random.Range(
                _minSpawnValue,
                _maxSpawnValue
            );

            Vector3 position =
                new Vector2(x, y);

            position = Vector3.ClampMagnitude(
                position,
                _data.SpawnDistanceMagnitude
            );

            position.y += _currentHeight;

            return position;
        }

        private void SpawnSlot(Vector3 position, SlotType type)
        {
            GameObject slotObject = Instantiate(
                type == SlotType.Stem ? _data.SlotPrefab : _data.EnvSlotPrefab,
                position,
                Quaternion.identity,
                _slotsManager.transform
            );

            Slot slot =
                slotObject.GetComponent<Slot>();

            if (slot == null)
            {
                Debug.LogError(
                    $"Slot prefab '{_data.SlotPrefab.name}' " +
                    $"does not contain a {nameof(Slot)} component.",
                    slotObject
                );

                Destroy(slotObject);
                return;
            }

            _slotsManager.AddSlot(slot);
        }

        public ModuleSaveData GetSaveData()
        {
            return _slotsManager.GetSaveData(
                _currentHeight
            );
        }

        public void Load(ModuleSaveData data)
        {
            if (data == null)
                return;

            _currentHeight =
                data.CurrentHeight;

            _slotsManager.Load(
                data,
                _data.SlotPrefab
            );
        }
    }
}