using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _followPosition;
    [SerializeField] private Vector3 _followCameraRotation;
    [SerializeField] private Vector3 _floorCameraPosition;
    [SerializeField] private Vector3 _floorCameraRotation;
    [SerializeField] private FloorStayCheck _floorStayCheck;

    private bool _isOnFloor;

    private void Update()
    {
        _isOnFloor = _floorStayCheck.IsOnFloor;

        if (_isOnFloor)
        {
            transform.localPosition = _floorCameraPosition;
            transform.localRotation = Quaternion.Euler(_floorCameraRotation);
        }
        else
        {
            transform.localPosition = _followPosition;
            transform.localRotation = Quaternion.Euler(_followCameraRotation);
        }
    }
}
