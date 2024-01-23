using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rayDistance = 0.1f;

    private Rigidbody2D _rigidbody2d;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0) 
        {
            _animator.SetBool("isRun", true);

            Rotate(horizontal);

            transform.Translate(_moveSpeed * Time.deltaTime * Vector2.right);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    private void Rotate(float horizontal) 
    {
        int degreeReversal;

        if (horizontal < 0)
        {
             degreeReversal = 180;
        }
        else
        {
            degreeReversal = 0;
        }

        transform.rotation = Quaternion.Euler(Vector2.up * degreeReversal);
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2d.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));
       
        if (hit.collider != null)
        {
            float jump = Input.GetAxisRaw("Jump");

            _rigidbody2d.AddForce(Vector2.up * jump * _jumpForce);
        }
    }
}
