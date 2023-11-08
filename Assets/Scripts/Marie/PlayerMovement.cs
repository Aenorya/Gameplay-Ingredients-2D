using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpStrength = 8f;
    [SerializeField] private float upGravity = 1f, downGravity = 5f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform feet;


    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private SoundPlayer _audioPlayer;


    private float horizontalMovement = 0;
    private bool jump = false, isGrounded = false;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioPlayer = GetComponent<SoundPlayer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -_speed;
            _spriteRenderer.flipX = true;
        }else if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = _speed;
            _spriteRenderer.flipX = false;
        }
        else
        {
            horizontalMovement = 0;
        }
        
        _animator.SetBool("Walk", (horizontalMovement != 0 && isGrounded));
        transform.position += new Vector3(horizontalMovement * Time.deltaTime, 0, 0);

        CheckGround();
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            isGrounded = false;
            _animator.SetBool("Jump", true);
            _audioPlayer.PlayAudio(SoundFX.Jump);
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpStrength), ForceMode2D.Impulse);
            jump = false;
        }

        if (!isGrounded && _rigidbody.velocity.y < 0)
        {
            _rigidbody.gravityScale = downGravity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("Jump", false);
            _rigidbody.gravityScale = upGravity;
        }
    }

    public void PlayWalkingSound()
    {
        _audioPlayer.PlayAudio(SoundFX.Walk);
    }
    
    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, groundLayers);
        if (hit)
        {
            isGrounded = true;
            _animator.SetBool("Jump", false);
            _rigidbody.gravityScale = upGravity;
        }
        else {
            isGrounded = false;
            _animator.SetBool("Jump", true);
            _rigidbody.gravityScale = downGravity;
        }
    }


}
