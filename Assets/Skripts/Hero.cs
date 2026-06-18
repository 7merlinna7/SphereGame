using UnityEngine;

public class Hero : MonoBehaviour
{
    private const int _rightSideRotation = 1;
    private const int _leftSideRotation = -1;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isMoveForwardKeyPressed;
    private bool _isMoveBackKeyPressed;
    private bool _isJumpKeyPressed;
    private bool _isRightRorationKeyPressed;
    private bool _isLeftRorationKeyPressed;

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
        if (_rigidbody.isKinematic == false)
        {

            if (Input.GetKey(KeyCode.W))
                _isMoveForwardKeyPressed = true;

            if (Input.GetKey(KeyCode.S))
                _isMoveBackKeyPressed = true;

            if (Input.GetKeyDown(KeyCode.Space))
                _isJumpKeyPressed = true;

            if (Input.GetKey(KeyCode.A))
                _isLeftRorationKeyPressed = true;

            if (Input.GetKey(KeyCode.D))
                _isRightRorationKeyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoveForwardKeyPressed)
        {
            ProcessMove(Vector3.forward);
            _isMoveForwardKeyPressed = false;
        }

        if (_isMoveBackKeyPressed)
        {
            ProcessMove(Vector3.back);
            _isMoveBackKeyPressed = false;
        }

        if (_isRightRorationKeyPressed)
        {
            ProcessRotate(_rightSideRotation);
            _isRightRorationKeyPressed = false;
        }    

        if (_isLeftRorationKeyPressed)
        {
            ProcessRotate(_leftSideRotation);
            _isLeftRorationKeyPressed=false;
        }

        if (_isJumpKeyPressed)
        {
            Jump();
            _isJumpKeyPressed = false;
        }
    }

    private void ProcessMove(Vector3 input) => _rigidbody.AddRelativeForce(input * _speed,ForceMode.Force);

    private void Jump() => _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

    private void ProcessRotate(int direction) => transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime * direction);
}
