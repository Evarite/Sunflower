using System.Collections.Generic;
using Sunflower.Modifiers;
using Sunflower.ModuleSlot;
using UnityEngine;

namespace Sunflower.Modules
{
    [CreateAssetMenu(fileName = "New Module", menuName = "Sunflower/Modules/Module Data")]
    public class ModuleData : ScriptableObject
    {
        [SerializeField] private string _moduleName;
        [SerializeField] private SlotType _allowedSlot;     // Stem / Environment
        [SerializeField] private int _cost;
        [SerializeField] private float _maxHealth;
        [SerializeField] private GameObject _alivePrefab;
        [SerializeField] private GameObject _deadPrefab;

        [SerializeField, Header("Модификаторы что применяются пока модуль на растении")]
        private List<ModifierData> activeModifiers = new List<ModifierData>();

        public SlotType AllowedSlot { get => _allowedSlot; }
        public int Cost { get => _cost; }
        public float MaxHealth { get => _maxHealth; }
        public GameObject AlivePrefab { get => _alivePrefab; }
        public GameObject DeadPrefab { get => _deadPrefab; }
        public string ModuleName { get => _moduleName; set => _moduleName = value; }
        public List<ModifierData> ActiveModifiers { get => activeModifiers; set => activeModifiers = value; }
    }
}