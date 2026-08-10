using Sunflower.Modifiers;
using Sunflower.ModuleSlot;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Modules
{
    [CreateAssetMenu(
        fileName = "New Module",
        menuName = "Sunflower/Modules/Module Data"
    )]
    public class ModuleData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _moduleName;

        [SerializeField] private SlotType _allowedSlot;

        [SerializeField] private int _cost;
        [SerializeField] private float _maxHealth;

        [SerializeField] private GameObject _alivePrefab;
        [SerializeField] private GameObject _deadPrefab;

        [SerializeField, Header("Модификаторы что применяются пока модуль на растении")]
        private List<ModifierData> _activeModifiers = new();

        public string Id => _id;
        public string ModuleName => _moduleName;
        public SlotType AllowedSlot => _allowedSlot;
        public int Cost => _cost;
        public float MaxHealth => _maxHealth;
        public GameObject AlivePrefab => _alivePrefab;
        public GameObject DeadPrefab => _deadPrefab;
        public List<ModifierData> ActiveModifiers => _activeModifiers;
    }
}