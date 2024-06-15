using UnityEngine;

public class SpringJump : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _jumpForce = 13;

    private GameObject _player;
    private Animator _animator;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        var playerRigitbody = _player.GetComponent<Rigidbody2D>();

        if (player != null && collision.attachedRigidbody.velocity.y < 0 &&
            collision.transform.position.y - collision.bounds.size.y / 2 > transform.position.y)
        {
            _animator.SetBool("Using", true);
            playerRigitbody.velocity = new Vector2(playerRigitbody.velocity.x, _jumpForce);
        }
    }
}
