using System.Collections;
using UnityEngine;

namespace Sunflower.Seeds
{

    public class SeedsIncome : MonoBehaviour
    {

        [SerializeField]
        private float _timeInterval = 2;
        [SerializeField]
        private float _seedsVelocity = 10;


        private WaitForSeconds _seedsInterval;

        private void Awake()
        {
            _seedsInterval = new WaitForSeconds(_timeInterval);
        }

        private void OnEnable()
        {
            Managers.LoseManager.Lost += StopSeedsUpdate;
            StartCoroutine(UpdateSeedsValue());
        }
        private void OnDisable()
        {
            Managers.LoseManager.Lost -= StopSeedsUpdate;
            StopAllCoroutines();
        }

        private void StopSeedsUpdate()
        {
            gameObject.SetActive(false);
            //To Do: добавить включение по ивенту в рестарте
        }


        private IEnumerator UpdateSeedsValue()
        {
            yield return _seedsInterval;

            while (true)
            {
                SeedsCounter.Value += (int)(_seedsVelocity * _timeInterval);
                yield return _seedsInterval;
            }
        }


    }

}