using System;
using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [Serializable]
    public class ModuleSlotSaveData
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private string _moduleId;

        public Vector3 Position => _position;
        public string ModuleId => _moduleId;

        public ModuleSlotSaveData(
            Vector3 position,
            string moduleId)
        {
            _position = position;
            _moduleId = moduleId;
        }
    }
}