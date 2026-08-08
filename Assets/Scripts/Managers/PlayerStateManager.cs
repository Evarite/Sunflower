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

        public List<SkillId> OwnedSkills { get => _ownedSkills.Skills; }

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
    }
}