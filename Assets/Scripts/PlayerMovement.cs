using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpStrength = 8f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float movement = 0;
    private bool jump = false, isGrounded = false;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement = -_speed;
            _spriteRenderer.flipX = true;
        }else if (Input.GetKey(KeyCode.D))
        {
            movement = _speed;
            _spriteRenderer.flipX = false;
        }
        else
        {
            movement = 0;
        }
        
        _animator.SetBool("Walk", (movement != 0 && isGrounded));
        transform.position += new Vector3(movement * Time.deltaTime, 0, 0);
        
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            isGrounded = false;
            _animator.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpStrength), ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("Jump", false);
        }
    }
}
