using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _floorOffset;
    [SerializeField] private Vector3 _floorRotate;
    [SerializeField] private FloorStayCheck _floorStayCheck;

    private bool _isOnFloor;


    private void Update()
    {
        _isOnFloor = _floorStayCheck.IsOnFloor; //не берет значение, у свойства выяснить поч
        Debug.Log(_isOnFloor);
    }

    private void LateUpdate()
    {
        if (_isOnFloor)
        {
            transform.position = _target.position + _floorOffset;
            transform.rotation = Quaternion.Euler(_floorRotate);
        }
        else
        {
            transform.position = _target.position + _offset;
        }
    }
}
