using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchEditPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _team1InputField;
    [SerializeField] private TMP_InputField _team2InputField;
    [SerializeField] private TMP_InputField _scoreInputField;
    [SerializeField] private Button _saveButton;
    [SerializeField] private MatchSaver _saver;
    [SerializeField] private MatchCreator _creator;

    private int _matchId;
    private MatchParameters _matchParameters;
    private Match _match;
    private string _matchIdFileName;

    private void Awake()
    {
        _matchIdFileName = "MatchId";
        _matchId = PlayerPrefs.GetInt(_matchIdFileName);

        CreateSavedMatches();
    }

    private void OnEnable()
    {
        _saveButton.onClick.AddListener(OnSaveButtonClick);
    }

    private void OnDisable()
    {
        _saveButton.onClick.RemoveListener(OnSaveButtonClick);
    }

    public void SetMatch(Match match)
    {
        _match = match;
        _matchParameters = match.Parameters;

        DrawParameters();
    }

    private void OnSaveButtonClick()
    {
        SetMatchParameters();

        if (_match == null)
        {
            if (_matchParameters.Team1Name.Length > 0 && _matchParameters.Team2Name.Length > 0 && _matchParameters.Score.Length > 0)
            {
                CreateMatch(_matchId++, _matchParameters);

                PlayerPrefs.SetInt(_matchIdFileName, _matchId);
            }
        }
        else
        {
            EditMatch();
        }
    }

    private void SetMatchParameters()
    {
        _matchParameters.Team1Name = _team1InputField.text;
        _matchParameters.Team2Name = _team2InputField.text;
        _matchParameters.Score = _scoreInputField.text;
    }

    private void CreateMatch(int id, MatchParameters parameters)
    {
        _creator.Create(id, parameters, this, _saver);
        _saver.Save(id, parameters);

        Clear();
    }

    private void EditMatch()
    {
        _match.SetParameters(_matchParameters);
        _saver.Save(_match.Id, _matchParameters);

        Clear();
    }

    private void Clear()
    {
        _team1InputField.text = string.Empty;
        _team2InputField.text = string.Empty;
        _scoreInputField.text = string.Empty;

        _match = null;
    }

    private void CreateSavedMatches()
    {
        bool isAvailableSave = false;

        for (int i = 0; i < _matchId; i++)
        {
            if (_saver.TryLoad(i, out _matchParameters))
            {
                CreateMatch(i, _matchParameters);

                isAvailableSave = true;
            }
        }

        if (isAvailableSave == false)
        {
            _matchId = 0;

            PlayerPrefs.SetInt(_matchIdFileName, _matchId);
        }
    }

    private void DrawParameters()
    {
        _team1InputField.text = _matchParameters.Team1Name;
        _team2InputField.text = _matchParameters.Team2Name;
        _scoreInputField.text = _matchParameters.Score;
    }
}
