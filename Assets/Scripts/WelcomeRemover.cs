using UnityEngine;

public class WelcomeRemover : MonoBehaviour
{
    [SerializeField] private GameObject _welcomeScreens;

    private int _openingCount;
    private string _openingCountFileName;

    private void Start()
    {
        _openingCountFileName = "OpeningCount";

        _openingCount = PlayerPrefs.GetInt(_openingCountFileName);

        if (_openingCount == 0)
        {
            gameObject.SetActive(false);
            _welcomeScreens.SetActive(true);

            PlayerPrefs.SetInt(_openingCountFileName, ++_openingCount);
        }
    }
}
