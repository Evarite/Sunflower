using UnityEngine;

namespace Sunflower.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private AudioSource _source;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _source = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip) => _source.PlayOneShot(clip);
    }
}