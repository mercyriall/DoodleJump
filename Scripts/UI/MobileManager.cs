using UnityEngine;
using UnityEngine.UI;

public class MobileManager : MonoBehaviour
{
    public static MobileManager instance;

    [SerializeField] private GameObject _gameOverCanas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ActivateButton()
    {
        _gameOverCanas.SetActive(true);
    }

    public void DeactivateButton()
    {
        if (!(_gameOverCanas.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color == new Color (0f, 0f, 0f, 0f)))
        {
            _gameOverCanas.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            _gameOverCanas.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

            _gameOverCanas.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color (0f, 0f, 0f, 0f);
            _gameOverCanas.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color (0f, 0f, 0f, 0f);
        }
    }
}
