using Sunflower.SkillTree.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.SaveSystem.Data
{
    [Serializable]
    public class GameSaveData
    {
        [SerializeField] private SunflowerSaveData _sunflowerSaveData;
        [SerializeField] private WealthSaveData _wealthSaveData;
        [SerializeField] private EventsSaveData _eventsSaveData;
        [SerializeField] private ModuleSaveData _moduleSaveData;
        [SerializeField] private List<SkillId> _ownedSkills;
        [SerializeField] private float _cameraSize;

        public SunflowerSaveData SunflowerSaveData => _sunflowerSaveData;

        public WealthSaveData WealthSaveData => _wealthSaveData;

        public EventsSaveData EventsSaveData => _eventsSaveData;

        public ModuleSaveData ModuleSaveData => _moduleSaveData;

        public List<SkillId> OwnedSkills => _ownedSkills;

        public float CameraSize => _cameraSize;

        public GameSaveData(
            SunflowerSaveData sunflowerSaveData,
            WealthSaveData wealthSaveData,
            EventsSaveData eventsSaveData,
            ModuleSaveData moduleSaveData,
            List<SkillId> ownedSkills,
            float cameraSize)
        {
            _sunflowerSaveData = sunflowerSaveData;
            _wealthSaveData = wealthSaveData;
            _eventsSaveData = eventsSaveData;
            _moduleSaveData = moduleSaveData;
            _ownedSkills = ownedSkills;
            _cameraSize = cameraSize;
        }
    }
}