using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target = null;
    private Quaternion _defaultRotation = new Quaternion();

    public Transform Target { get { return _target; } set { _target = value; } }


    private void Awake()
    {
        _defaultRotation = transform.rotation;
        this.enabled = false;
    }

    private void Update()
    {
        LookAt2D();
    }

    private void LookAt2D()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetDefaultRotation()
    {
        transform.rotation = _defaultRotation;
    }
}