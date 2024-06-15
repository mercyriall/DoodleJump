using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _jumpForce = 21;

    private GameObject _player;
    private Animator _animator;
    private GameObject _spownObject;
    private float _lastPosition;

    private int _countLeftSpownObject;
    private int _countRightSpownObject;
    private int _countHeadSpownObject;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _lastPosition = _player.transform.position.y;
        _animator = GetComponent<Animator>();
        _spownObject = GameObject.Find("Head");
    }

    private void Update()
    {
        _countLeftSpownObject = GameObject.Find("LeftBack").gameObject.transform.childCount;
        _countRightSpownObject = GameObject.Find("RightBack").gameObject.transform.childCount;
        _countHeadSpownObject = GameObject.Find("Head").gameObject.transform.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        var playerRigitbody = _player.GetComponent<Rigidbody2D>();

        if (player != null && (_countLeftSpownObject == 0 && _countRightSpownObject == 0 && _countHeadSpownObject == 0))
        {
            transform.position = _spownObject.transform.position;
            transform.SetParent(_spownObject.transform);
            _animator.SetBool("UsingPropeller", true);
            playerRigitbody.velocity = new Vector2(playerRigitbody.velocity.x, _jumpForce);

            StartCoroutine(CheckPosition());
        }
    }

    IEnumerator CheckPosition()
    {
        while (_lastPosition <= _player.transform.position.y)
        {
            _lastPosition = _player.transform.position.y;
            yield return new WaitForSeconds(0.2f);
        }

        ClosePropellerAnimation();
    }

    private void ClosePropellerAnimation()
    {
        _animator.SetBool("UsingPropeller", false);
        Destroy(this.gameObject);
    }
}
