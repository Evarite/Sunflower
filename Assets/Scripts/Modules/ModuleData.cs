using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Modules
{
    [CreateAssetMenu(fileName = "New Module Data", menuName = "Sunflower/Modules/Module Data")]
    public class ModuleData : ScriptableObject
    {
        [SerializeField] private ModuleType _type;        // Active / Passive
        [SerializeField] private SlotType _allowedSlot;     // Stem / Environment
        [SerializeField] private int _cost;
        [SerializeField] private float _maxHealth;
        [SerializeField] private GameObject _prefab;

        public ModuleType Type { get => _type; }
        public SlotType AllowedSlot { get => _allowedSlot; }
        public int Cost { get => _cost; }
        public float MaxHealth { get => _maxHealth; }
        public GameObject Prefab { get => _prefab; }
    }
}
