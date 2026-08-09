using Sunflower.Growth;
using Sunflower.ModuleSlot;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Managers.Spawn
{
    [System.Serializable]
    public class SpawnManagerData
    {
        [Header("Sunflower")]
        [SerializeField] private SunflowerGrowth _sunflowerGrowth;

        [Header("Slots")]
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private GameObject _envSlotPrefab;
        [SerializeField] private int _minSpawnCount = 1;
        [SerializeField] private int _maxSpawnCount = 3;
        [SerializeField, Range(0f, 1f)] private float _envSlotChance = 0.2f;

        [SerializeField] private List<Slot> _allSlots = new();

        [Header("Distance")]
        [SerializeField] private float _spawnInterval = 100f;
        [SerializeField] private float _spawnDistanceMagnitude = 2f;
        [SerializeField] private float _envSlotX = -7;

        public GameObject SlotPrefab { get => _slotPrefab; }
        public GameObject EnvSlotPrefab { get => _envSlotPrefab; }
        public int MinSpawnCount { get => _minSpawnCount; }
        public int MaxSpawnCount { get => _maxSpawnCount; }
        public float EnvSlotChance { get => _envSlotChance; }
        public List<Slot> AllSlots { get => _allSlots; }
        public float SpawnInterval { get => _spawnInterval; }
        public float SpawnDistanceMagnitude { get => _spawnDistanceMagnitude; }
        public float EnvSlotX { get => _envSlotX; set => _envSlotX = value; }
        public SunflowerGrowth SunflowerGrowth { get => _sunflowerGrowth; set => _sunflowerGrowth = value; }
    }
}
