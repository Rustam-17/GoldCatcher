using UnityEngine;

public class MatchCreator : MonoBehaviour
{
    [SerializeField] private GameObject _matchPrefab;
    [SerializeField] private Transform _content;

    private GameObject _matchObject;
    private Match _match;

    public void Create(int id, MatchParameters parameters, MatchEditPanel editPanel, MatchSaver saver)
    {
        _matchObject = Instantiate(_matchPrefab, _content);
        _matchObject.transform.SetSiblingIndex(1);

        _match = _matchObject.GetComponent<Match>();
        _match.SetParameters(id, parameters, editPanel, saver);
    }
}
