using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private GameObject[] _buffPlatforms;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private GameObject _spowns;
    [SerializeField] private float _platformDistance = 2.5f;

    private float _spownPosition;

    private void Start()
    {
        _spownPosition = _spowns.transform.position.y;
        Vector3 pos = new(_spowns.transform.position.x, _spownPosition, _spowns.transform.position.z);
        Spown(_platforms[0], pos);
    }

    private void FixedUpdate()
    {
        CheckSpownPosition();
    }

    private void CheckSpownPosition()
    {
        float positionNow;

        positionNow = _spowns.transform.position.y;

        if (_spownPosition != positionNow && Mathf.Round(positionNow) >= _spownPosition + _platformDistance)
        {
            _spownPosition = positionNow;

            Vector3 defoultVector = Vector3.zero;
            Vector3 position = ChoosePosition(defoultVector);
            GameObject platform = ChoosePlatform();
            Spown(platform, position);

            if (Random.Range(0.0f, 1.0f) > 0.95f)
            {
                Vector3 buffPlatformPosition = ChooseBuffPlatformPosition(position);
                GameObject buffPlatform = ChooseBuffPlatform();
                Spown(buffPlatform, buffPlatformPosition);
            }
            else if (Random.Range(0.0f, 1.0f) > 0.95f)
            {
                Vector3 enemyPosition = ChooseEnemyPosition(position);
                GameObject enemy = ChooseEnemy();
                Spown(enemy, enemyPosition);
            }

            if (Random.Range(0.0f, 1.0f) > 0.75f)
            {
                Vector3 secondPosition = ChoosePosition(position);
                GameObject secondPlatform = ChoosePlatform();
                Spown(secondPlatform, secondPosition);
            }
        }
        
    }

    private Vector3 ChooseBuffPlatformPosition(Vector3 position)
    {
        if (position.x > 0)
        {
            Vector3 pos = new(Random.Range(-2.25f, -0.5f), _spownPosition + Random.Range(-0.1f, 0.1f), _spowns.transform.position.z);
            return pos;
        }
        else
        {
            Vector3 pos = new(Random.Range(0.5f, 2.25f), _spownPosition + Random.Range(-0.1f, 0.1f), _spowns.transform.position.z);
            return pos;
        }
    }

    private GameObject ChooseBuffPlatform()
    {
        int platformsCount = _buffPlatforms.Length;
        return _buffPlatforms[Random.Range(0, platformsCount)];
    }

    private Vector3 ChooseEnemyPosition(Vector3 position)
    {
        if (position.x > 0)
        {
            Vector3 pos = new(Random.Range(-2.25f, -0.5f), _spownPosition + Random.Range(-0.50f, 0.50f), _spowns.transform.position.z);
            return pos;
        }
        else
        {
            Vector3 pos = new(Random.Range(0.5f, 2.25f), _spownPosition + Random.Range(-0.50f, 0.50f), _spowns.transform.position.z);
            return pos;
        }
    }

    private GameObject ChooseEnemy()
    {
        int enemysCount = _enemys.Length;
        return _enemys[Random.Range(0, enemysCount)];
    }

    private Vector3 ChoosePosition(Vector3 firstPos)
    {
        if (firstPos.x == 0)
        {
            Vector3 pos = new(Random.Range(-2.25f, 2.25f), _spownPosition + Random.Range(-0.1f, 0.1f), _spowns.transform.position.z);
            return pos;
        }
        else
        {
            if (firstPos.x > 0)
            {
                Vector3 pos = new(Random.Range(-2.25f, -0.5f), _spownPosition + Random.Range(-0.4f, 0.4f), _spowns.transform.position.z);
                return pos;
            }
            else
            {
                Vector3 pos = new(Random.Range(0.5f, 2.25f), _spownPosition + Random.Range(-0.4f, 0.4f), _spowns.transform.position.z);
                return pos;
            }
        }
    }

    private GameObject ChoosePlatform()
    {
        int platformsCount = _platforms.Length;
        return _platforms[Random.Range(0, platformsCount)];
    }

    private void Spown(GameObject platform, Vector3 pos)
    {
        Instantiate(platform, pos, Quaternion.identity);
    }
}
