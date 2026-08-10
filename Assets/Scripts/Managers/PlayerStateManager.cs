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

        public List<SkillId> OwnedSkills { get => _ownedSkills.PurchasedSkills; }
        public int PointsEarned { get => _pointsEarned; set => _pointsEarned = value; }

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

        public void InitializeSkills(List<SkillId> skills) => _ownedSkills.Initialize(skills);
    }
}