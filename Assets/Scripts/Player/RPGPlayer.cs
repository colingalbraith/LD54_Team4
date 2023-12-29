using UnityEngine;

public class RPGPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private Rigidbody2D _rb;
    private BoxCollider2D _col;

    private float _horDirection;
    private float _verDirection;
    private Vector3 _acc = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horDirection = Input.GetAxisRaw("Horizontal");
        _verDirection = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move(_horDirection, _verDirection);
    }

    private void Move(float horMove, float verMove)
    {
        Vector3 targetVelocity = new Vector2(horMove, verMove).normalized * _speed;
        float decelTime = 0.05f;
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _acc, decelTime);

        // probably have some stuff to adjust player orientation but nah lol
    }

}
