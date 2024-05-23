using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] TMP_Text _team1Name;
    [SerializeField] TMP_Text _team2Name;
    [SerializeField] TMP_Text _score;

    public void SetParameters(string team1Name, string team2Name, string score)
    {
        _team1Name.text = team1Name;
        _team2Name.text = team2Name;
        _score.text = score;
    }
}
