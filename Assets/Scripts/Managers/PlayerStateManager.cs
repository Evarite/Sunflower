using Sunflower.SkillTree.Data;
using UnityEngine;

namespace Sunflower.Managers
{
    public class PlayerStateManager : MonoBehaviour
    {
        public static PlayerStateManager Instance { get; private set; }

        [SerializeField] private OwnedSkills _ownedSkills = new();

        public OwnedSkills OwnedSkills { get => _ownedSkills; }

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