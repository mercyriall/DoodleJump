using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _background;
    [SerializeField] private GameObject _platformSpawners;
    [SerializeField] private int _firstPlatformPlace = 6;

    private void Update()
    {
        var generatePlatform = GetComponent<PlatformGenerate>();

        if (transform.position.y < _target.position.y)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            _background.transform.position = new Vector3(_background.transform.position.x, transform.position.y, _background.transform.position.z);

            _platformSpawners.transform.position = new Vector3(
                _platformSpawners.transform.position.x, transform.position.y + _firstPlatformPlace, _platformSpawners.transform.position.z);
        }
    }
}
