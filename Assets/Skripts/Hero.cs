using UnityEngine;

public class Hero : MonoBehaviour
{
    private static string HorizontalAxdisName = "Horizontal";
    private static string VerticalAxisName = "Vertical";
    private const int _rightSideRotation = 1;
    private const int _leftSideRotation = -1;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;

    private Vector3 _input;
    private Vector3 _normalizedInput;
    private Vector3 _inputRotation;
    private Vector3 _normalizedInputRotation;

    private bool _isJumpKeyPressed;

    public void StopHero() => _rigidbody.isKinematic = true;

    public void StartHero()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    private void Awake()
    {
        StartHero();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJumpKeyPressed = true;
    }

    private void FixedUpdate()
    {
        if (_rigidbody.isKinematic == false)
        {
            _input = new Vector3(0, 0, Input.GetAxisRaw(VerticalAxisName));
            _normalizedInput = _input.normalized;
            ProcessMove(_normalizedInput);

            float direction = Input.GetAxisRaw(HorizontalAxdisName);
            ProcessRotate(direction);

            if (_isJumpKeyPressed)
            {
                Jump();
                _isJumpKeyPressed = false;
            }
        }
    }

    private void ProcessMove(Vector3 input) => _rigidbody.AddRelativeForce(input * _speed,ForceMode.Force);

    private void Jump() => _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

    private void ProcessRotate(float direction) => transform.Rotate(Vector3.up* _rotationSpeed * Time.deltaTime * direction);
}
