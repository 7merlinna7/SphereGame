using UnityEngine;

public class GemRotator : MonoBehaviour
{
    private int _firstSide = 1;
    private int _secondSide = -1;

    [SerializeField] private float _rotateSpeed = 50;

    private int _currentSide;

    private void Awake()
    {
        _currentSide = DetermineSide();
    }

    private int DetermineSide()
    {
        int chance = Random.Range(0, 2);
        return chance == 0 ? _firstSide : _secondSide;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _currentSide *  _rotateSpeed * Time.deltaTime);
    }
}
