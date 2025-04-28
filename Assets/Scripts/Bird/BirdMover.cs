using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    private int _force = 10;
    private float _rotationSpeed = 1f;
    private int _maxRotationZ = 30;
    private int _minRotationZ = -60;

    private Vector2 _startPosition;
    private Rigidbody2D _rigidbody2d;
    private Quaternion _maxRotation;
    private Quaternion _minRorarion;
    

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
        _minRorarion = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2d.velocity = new Vector2(0, _force);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRorarion, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2d.velocity = Vector2.zero;
    }
}
