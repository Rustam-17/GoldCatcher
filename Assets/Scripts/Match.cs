using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Match : MonoBehaviour
{
    [SerializeField] TMP_Text _team1Name;
    [SerializeField] TMP_Text _team2Name;
    [SerializeField] TMP_Text _score;
    [SerializeField] Button _editButton;
    [SerializeField] Button _removeButton;
    [SerializeField] MatchSaver _saver;

    private MatchEditPanel _editPanel;
    private int _id;
    private MatchParameters _parameters;

    public MatchParameters Parameters => _parameters;
    public int Id => _id;

    private void OnEnable()
    {
        _editButton.onClick.AddListener(OnEditButtonClick);
        _removeButton.onClick.AddListener(OnRemoveButtonClick);
    }

    private void OnDisable()
    {
        _editButton.onClick.AddListener(OnEditButtonClick);
        _removeButton.onClick.RemoveListener(OnRemoveButtonClick);
    }

    public void SetParameters(int id, MatchParameters parameters, MatchEditPanel editPanel, MatchSaver saver)
    {
        _id = id;
        _parameters = parameters;
        _editPanel = editPanel;
        _saver = saver;

        DrawParameters();
    }

    public void SetParameters(MatchParameters parameters)
    {
        _parameters = parameters;

        DrawParameters();
    }

    private void OnEditButtonClick()
    {
        _editPanel.SetMatch(this);
    }

    private void OnRemoveButtonClick()
    {
        _saver.RemoveSave(_id);

        Destroy(gameObject);
    }

    private void DrawParameters()
    {
        _team1Name.text = _parameters.Team1Name;
        _team2Name.text = _parameters.Team2Name;
        _score.text = _parameters.Score;
    }
}
