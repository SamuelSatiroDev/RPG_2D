using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class RangeChecker : MonoBehaviour
{
    [TagSelector]
    [SerializeField] private string _objectCollisionTag = string.Empty;
    private Transform _transformCollision = null;

    public delegate void EventHandler(Transform target);
    public delegate void EventHandlerTrigger();

    public event EventHandler OnSetTarget;

    private void OnTriggerStay2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag(_objectCollisionTag) == false || _transformCollision != null)
        {
            return;
        }

        _transformCollision = collision.transform;

        OnSetTarget?.Invoke(_transformCollision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_objectCollisionTag) == false || _transformCollision != collision.transform)
        {
            return;
        }

        _transformCollision = null;

        OnSetTarget?.Invoke(_transformCollision);
    }

    private void Reset()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }
}