using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0f;

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
    }
}