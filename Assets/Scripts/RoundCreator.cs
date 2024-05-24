using System.Collections.Generic;
using UnityEngine;

public class RoundCreator : MonoBehaviour
{
    [SerializeField] private GameObject _roundPrefab;
    [SerializeField] private Transform _content;

    private GameObject _roundObject;
    private TimerRound _round;
    private int _roundCount;

    private List<TimerRound> _rounds;

    private void Start()
    {
        _rounds = new List<TimerRound>();
    }

    public void Create(string time)
    {
        _roundObject = Instantiate(_roundPrefab, _content);
        _roundObject.transform.SetSiblingIndex(0);

        _round = _roundObject.GetComponent<TimerRound>();
        _round.SetParameters(time, ++_roundCount);

        _rounds.Add( _round );
    }

    public void Restart()
    {
        foreach (TimerRound round in _rounds)
        {
            Destroy(round.gameObject);
        }

        _rounds.Clear();
        _roundCount = 0;
    }
}
