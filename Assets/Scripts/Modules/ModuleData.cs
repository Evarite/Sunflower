using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Modules
{
    [CreateAssetMenu(fileName = "New Module", menuName = "Sunflower/Modules/Module Data")]
    public class ModuleData : ScriptableObject
    {
        [SerializeField] private SlotType _allowedSlot;     // Stem / Environment
        [SerializeField] private int _cost;
        [SerializeField] private float _maxHealth;
        [SerializeField] private GameObject _alivePrefab;
        [SerializeField] private GameObject _deadPrefab;

        public SlotType AllowedSlot { get => _allowedSlot; }
        public int Cost { get => _cost; }
        public float MaxHealth { get => _maxHealth; }
        public GameObject AlivePrefab { get => _alivePrefab; }
        public GameObject DeadPrefab { get => _deadPrefab; }
    }
}