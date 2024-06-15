using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _platform;

    private PlayerMovement _player;



    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(_target.position.y <= transform.position.y)
        {
            _player.Dead();
        }
    }
}
