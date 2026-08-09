using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0f, 0f, 100f);

    private void Update() => transform.Rotate(_rotationSpeed * Time.deltaTime);
}