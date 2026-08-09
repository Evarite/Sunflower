using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sunflower.Loading
{
    [RequireComponent(typeof(Image))]
    public class LoadingScreenBackground : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _backgrounds;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();

            int randomValue = Random.Range(0, _backgrounds.Count - 1);
            _image.sprite = _backgrounds[randomValue];
        }
    }
}