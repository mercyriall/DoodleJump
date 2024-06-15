using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _jumpForce = 33;

    private GameObject _player;
    private Animator _animator;

    private GameObject _leftSpownObject;
    private GameObject _rightSpownObject;
    
    private int _countLeftSpownObject;
    private int _countRightSpownObject;
    private int _countHeadSpownObject;

    private float _lastPosition;
    private bool _flipFlag = false;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().flipX = true;

        _player = GameObject.FindGameObjectWithTag("Player");
        _lastPosition = _player.transform.position.y;

        _animator = GetComponent<Animator>();
        _leftSpownObject = GameObject.Find("LeftBack");
        _rightSpownObject = GameObject.Find("RightBack");
    }

    private void Update()
    {
        if (_flipFlag)
        {
            if (_player.GetComponent<SpriteRenderer>().flipX)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                transform.position = _rightSpownObject.transform.position;
                transform.SetParent(_rightSpownObject.transform);
            }
            else if (!_player.GetComponent<SpriteRenderer>().flipX)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                transform.position = _leftSpownObject.transform.position;
                transform.SetParent(_leftSpownObject.transform);
            }
        }

        _countLeftSpownObject = GameObject.Find("LeftBack").gameObject.transform.childCount;
        _countRightSpownObject = GameObject.Find("RightBack").gameObject.transform.childCount;
        _countHeadSpownObject = GameObject.Find("Head").gameObject.transform.childCount;

        Debug.Log(_countLeftSpownObject + " " + _countRightSpownObject + " " + _countHeadSpownObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        var playerRigitbody = _player.GetComponent<Rigidbody2D>();


        if (player != null && _countLeftSpownObject == 0 && _countRightSpownObject == 0 && _countHeadSpownObject == 0)
        {
            _flipFlag = true;
            _animator.SetBool("StartUsing", true);
            playerRigitbody.velocity = new Vector2(playerRigitbody.velocity.x, _jumpForce);
        }
    }

    IEnumerator CheckPosition()
    {
        _animator.SetBool("StartUsing", false);
        _animator.SetBool("CloseUsing", true);
        while (_lastPosition <= _player.transform.position.y)
        {
            _lastPosition = _player.transform.position.y;
            yield return new WaitForSeconds(0.2f);
        }

        CloseJetpackAnimation();
    }

    private void CloseJetpackAnimation()
    {
        _animator.SetBool("CloseUsing", false);
        Destroy(this.gameObject);
    }
}
