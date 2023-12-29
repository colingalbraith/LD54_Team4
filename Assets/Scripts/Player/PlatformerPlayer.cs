using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _jumpVel = 35;
    [SerializeField] private float _jumpCooldown = 0.5f;  // Jump cooldown in seconds

    private Rigidbody2D _rb;
    private Collider2D _col;
    private Animator _anim;

    private float _horDirection;
    private bool _pressedJump;
    private bool _jumped;
    private Vector3 _acc = Vector3.zero;
    private float _jumpCooldownTimer;  // Timer to track jump cooldown

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horDirection = Input.GetAxisRaw("Horizontal") * _speed;
        _anim.SetBool("Moving", _horDirection != 0);
        _anim.SetBool("grounded", IsGrounded());

        // Check for jump input and cooldown timer
        if (Input.GetButtonDown("Jump") && _jumpCooldownTimer <= 0)
        {
            _pressedJump = true;
            _jumpCooldownTimer = _jumpCooldown;  // Set the jump cooldown timer
        }

        // Update the jump cooldown timer
        if (_jumpCooldownTimer > 0)
            _jumpCooldownTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (_pressedJump)
            _pressedJump = !_jumped;

        _jumped = _pressedJump;

        Move(_horDirection * Time.fixedDeltaTime, _pressedJump);

        _pressedJump = false;  // reset
    }

    private void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
        float decelTime = 0.05f;
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _acc, decelTime);

        // adjust player orientation accordingly
        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        bool grounded = IsGrounded();
        if (grounded && jump)
        {
            _anim.SetTrigger("jump");
            Vector2 currVelocity = _rb.velocity;
            currVelocity.y = _jumpVel;
            _rb.velocity = currVelocity;
            _rb.AddForce(new Vector2(0f, _jumpVel), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float playerHeight = _col.bounds.size.y;
        float extraHeight = 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(_col.bounds.center, Vector2.down, playerHeight / 2 + extraHeight);
        return hit.collider != null;
    }
}
