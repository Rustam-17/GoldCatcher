using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchCreator : MonoBehaviour
{
    [SerializeField] private Button _createButton;
    [SerializeField] private TMP_InputField _team1InputField;
    [SerializeField] private TMP_InputField _team2InputField;
    [SerializeField] private TMP_InputField _scoreInputField;
    [SerializeField] private GameObject _matchPrefab;
    [SerializeField] private Transform _content;

    private string _team1Name;
    private string _team2Name;
    private string _score;
    private GameObject _matchObject;
    private Match _match;

    private void OnEnable()
    {
        _team1InputField.onEndEdit.AddListener(OnEndEditTeam1Name);
        _team2InputField.onEndEdit.AddListener(OnEndEditTeam2Name);
        _scoreInputField.onEndEdit.AddListener(OnEndEditScore);

        _createButton.onClick.AddListener(OnCreateButtonClick);
    }

    private void OnDisable()
    {
        _team1InputField.onEndEdit.RemoveListener(OnEndEditTeam1Name);
        _team2InputField.onEndEdit.RemoveListener(OnEndEditTeam2Name);
        _scoreInputField.onEndEdit.RemoveListener(OnEndEditScore);

        _createButton.onClick.RemoveListener(OnCreateButtonClick);
    }

    private void OnEndEditTeam1Name(string text)
    {
        _team1Name = text;
    }

    private void OnEndEditTeam2Name(string text)
    {
        _team2Name = text;
    }

    private void OnEndEditScore(string text)
    {
        _score = text;
    }
    private void OnCreateButtonClick()
    {
        Create();
    }

    private void Create()
    {
        _matchObject = Instantiate(_matchPrefab, _content);

        _match = _matchObject.GetComponent<Match>();
        _match.SetParameters(_team1Name, _team2Name, _score);
    }
}
