using UnityEngine;

public class MatchSaver : MonoBehaviour
{
    private int _matchId;
    private string _team1FileName;
    private string _team2FileName;
    private string _scoreFileName;

    private MatchParameters _matchParameters;

    private string Team1FileName => _team1FileName + _matchId;
    private string Team2FileName => _team2FileName + _matchId;
    private string ScoreFileName => _scoreFileName + _matchId;

    private void OnEnable()
    {
        _team1FileName = "Team1";
        _team2FileName = "Team2";
        _scoreFileName = "Score";
    }

    public void Save(int id, MatchParameters matchParameters)
    {
        _matchId = id;
        _matchParameters = matchParameters;

        PlayerPrefs.SetString(Team1FileName, _matchParameters.Team1Name);
        PlayerPrefs.SetString(Team2FileName, _matchParameters.Team2Name);
        PlayerPrefs.SetString(ScoreFileName, _matchParameters.Score);
    }

    public bool TryLoad(int id, out MatchParameters parameters)
    {
        _matchId = id;

        _matchParameters.Team1Name = PlayerPrefs.GetString(Team1FileName);
        _matchParameters.Team2Name = PlayerPrefs.GetString(Team2FileName);
        _matchParameters.Score = PlayerPrefs.GetString(ScoreFileName);
        parameters = _matchParameters;

        return PlayerPrefs.HasKey(Team1FileName);
    }

    public void RemoveSave(int id)
    {
        _matchId = id;

        PlayerPrefs.DeleteKey(Team1FileName);
        PlayerPrefs.DeleteKey(Team2FileName);
        PlayerPrefs.DeleteKey(ScoreFileName);
    }
}
