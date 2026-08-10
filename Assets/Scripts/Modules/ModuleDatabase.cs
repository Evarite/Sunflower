using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Modules
{
    [CreateAssetMenu(
        fileName = "Module Database",
        menuName = "Sunflower/Modules/Module Database"
    )]
    public class ModuleDatabase : ScriptableObject
    {
        [SerializeField] private List<ModuleData> _modules = new();

        private Dictionary<string, ModuleData> _lookup;

        private void Initialize()
        {
            if (_lookup != null)
                return;

            _lookup = new Dictionary<string, ModuleData>();

            foreach (ModuleData module in _modules)
            {
                if (module == null)
                    continue;

                if (string.IsNullOrEmpty(module.Id))
                {
                    Debug.LogWarning(
                        $"Module '{module.name}' has no ID.",
                        module
                    );

                    continue;
                }

                if (_lookup.ContainsKey(module.Id))
                {
                    Debug.LogError(
                        $"Duplicate module ID '{module.Id}'.",
                        module
                    );

                    continue;
                }

                _lookup.Add(module.Id, module);
            }
        }

        public ModuleData GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            Initialize();

            _lookup.TryGetValue(id, out ModuleData module);

            return module;
        }
    }
}