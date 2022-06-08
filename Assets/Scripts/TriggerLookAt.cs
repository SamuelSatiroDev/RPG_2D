using UnityEngine;

public class TriggerLookAt : MonoBehaviour
{
    [SerializeField] private LookAtTarget _lookAtTarget = null;
    [SerializeField] private RangeChecker _rangeChecker = null;

    private void OnEnable()
    {
        _rangeChecker.OnSetTarget += SetTarget;
    }

    private void OnDisable()
    {
        _rangeChecker.OnSetTarget -= SetTarget;
    }

    public void SetTarget(Transform target)
    {
        _lookAtTarget.Target = target;
        _lookAtTarget.enabled = _lookAtTarget.Target == null ? false : true;

        if (_lookAtTarget.Target != null)
        {
            return;
        }

        _lookAtTarget.SetDefaultRotation();
    }
}