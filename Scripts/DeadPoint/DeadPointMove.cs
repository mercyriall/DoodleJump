using UnityEngine;

public class DeadPointMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private int _deadRange;

    private void Update()
    {
        if (transform.position.y + 5.5 < _target.position.y)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y - 5.5f, transform.position.z);
        }
    }
}
