using System.Collections;
using UnityEngine;

namespace Sunflower.Growth
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(SunflowerGrowth))]
    [AddComponentMenu("Sunflower/Growth/Stage Sprites Swap")]
    public class StageSpritesSwap : MonoBehaviour
    {
        [SerializeField] private GrowthStagesData _stages;

        private SpriteRenderer _spriteRenderer;
        private SunflowerGrowth _sunflowerGrowth;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _sunflowerGrowth = GetComponent<SunflowerGrowth>();
        }

        private void OnEnable() => StartCoroutine(Swap());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Swap()
        {
            for (int i = 0; i < _stages.GrowthStages.Count; i++)
            {
                var stage = _stages.GrowthStages[i];
                _spriteRenderer.sprite = stage.Sprite;

                yield return new WaitUntil(() => _sunflowerGrowth.Height >= stage.MaxHeight);
            }
        }
    }
}