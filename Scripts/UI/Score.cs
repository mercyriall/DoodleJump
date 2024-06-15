using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private GameObject _player;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _currentScoreText.text = _score.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void Update()
    {
        if (_score < _player.transform.position.y)
        {
            UpdateScore(Mathf.Round(_player.transform.position.y));
        }
    }

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
    }

    private void UpdateScore(float scoreNow)
    {
        _score = ((int)scoreNow);
        _currentScoreText.text = _score.ToString();

        UpdateHighScore();
    }
}
