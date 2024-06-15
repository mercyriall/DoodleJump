using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private bool _platform;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;

    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigitbody;
    [SerializeField] private bool _lookRight;

    private Animator _animator;

    private void Awake()
    {
        _platform = Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (Application.isMobilePlatform == true)
        {
            MobileManager.instance.ActivateButton();
        }
    }

    private void Update()
    {
        if (Application.isMobilePlatform == false)
        {
            MoveDesctop();
        }
    }

    public void Dead()
    {
        GameManager.instance.GameOver();
    }

    public void MoveMobileRight()
    {
        MobileManager.instance.DeactivateButton();
        FlipMobile("Right");
        _rigitbody.velocity = new Vector2(_moveSpeed-2 * Time.deltaTime, _rigitbody.velocity.y);
    }

    public void MoveMobileLeft()
    {
        MobileManager.instance.DeactivateButton();
        FlipMobile("Left");
        _rigitbody.velocity = new Vector2(-_moveSpeed+2 * Time.deltaTime, _rigitbody.velocity.y);
    }
    
    public void MoveMobileStop()
    {
        _rigitbody.velocity = new Vector2(0, _rigitbody.velocity.y);
    }

    private void FlipMobile(string button)
    {
        if (button == "Right")
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (button == "Left")
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MoveDesctop()
    {
        var moveInput = Input.GetAxis("Horizontal");

        CheckFlipDesctop(moveInput);

        _rigitbody.velocity = new Vector2(moveInput * _moveSpeed, _rigitbody.velocity.y);
    }

    private void CheckFlipDesctop(float moveInput)
    {
        if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (moveInput > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void CloseJumpAnimation()
    {
        _animator.SetBool("Jump", false);
    }
}