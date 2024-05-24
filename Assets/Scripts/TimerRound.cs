using TMPro;
using UnityEngine;

public class TimerRound : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _countText;

    private string _roundText;
    private string _roundCountText;

    private void OnEnable()
    {
        _roundText = "Round";
    }

    public void SetParameters(string time, int number)
    {
        _timeText.text = time;

        _roundCountText = $"{_roundText} {number}";
        _countText.text = _roundCountText;
    }
}
