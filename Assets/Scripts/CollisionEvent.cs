using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CollisionEvent : MonoBehaviour
{
    [TagSelector]
    [SerializeField] private string _collisionTag = string.Empty;

    public delegate void EventHandler();

    public event EventHandler OnCollisionEnter;
    public event EventHandler OnCollisionExit;
    public event EventHandler OnCollisionStay;

    public event EventHandler OnTriggerEnter;
    public event EventHandler OnTriggerExit;
    public event EventHandler OnTriggerStay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnCollisionExit?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnCollisionStay?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnTriggerEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnTriggerExit?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_collisionTag) == false)
        {
            return;
        }

        OnTriggerStay?.Invoke();
    }

    private void Reset()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }
}