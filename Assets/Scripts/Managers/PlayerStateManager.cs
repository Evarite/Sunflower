using Sunflower.SkillTree.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Sunflower.Managers
{
    [AddComponentMenu("Sunflower/Managers/PLayer State Manager")]
    public class PlayerStateManager : MonoBehaviour
    {
        public static PlayerStateManager Instance { get; private set; }

        [SerializeField] private OwnedSkills _ownedSkills = new();

        private int _pointsEarned;

        private int _currentRun = 0;

        public List<SkillId> OwnedSkills { get => _ownedSkills.PurchasedSkills; }
        public int PointsEarned { get => _pointsEarned; set => _pointsEarned = value; }
        public int CurrentRun => _currentRun;
        public bool CanIncreaseRun { get; set; } = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void IncreaseRun()
        {
            _currentRun++;
            CanIncreaseRun = false;
        }

        public void InitializeSkills(List<SkillId> skills) => _ownedSkills.Initialize(skills);
    }
}