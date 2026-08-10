using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sunflower.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;

        private static string _targetScene;

        public static void LoadScene(string sceneName)
        {
            _targetScene = sceneName;
            SceneManager.LoadScene("LoadingScene");
        }

        private void Start() => StartCoroutine(LoadTargetScene());

        private IEnumerator LoadTargetScene()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_targetScene);

            operation.allowSceneActivation = false;

            while (operation.progress < 0.9f)
            {
                float progress = operation.progress / 0.9f;

                if (_progressBar != null)
                    _progressBar.value = progress;

                yield return null;
            }

            if (_progressBar != null)
                _progressBar.value = 1f;

            yield return new WaitForSeconds(1f);

            operation.allowSceneActivation = true;
        }
    }
}
