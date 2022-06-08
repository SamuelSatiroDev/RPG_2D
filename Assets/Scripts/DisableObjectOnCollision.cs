using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class DisableObjectOnCollision : MonoBehaviour
{
    private CollisionEvent _collisionEvent = null;

    private void Awake()
    {
        _collisionEvent = GetComponent<CollisionEvent>();
    }

    private void OnEnable()
    {
        _collisionEvent.OnTriggerEnter += DisableGameObject;
    }

    private void OnDisable()
    {
        _collisionEvent.OnTriggerEnter -= DisableGameObject;
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}