using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text _clock;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _roundButton;
    [SerializeField] private RoundCreator _roundCreator;

    private DateTime _playTime;
    private TimeSpan _elapsedTime;
    private bool _isPlaying;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
        _roundButton.onClick.AddListener(OnRoundButtonClick);

        _roundButton.interactable = false;
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _stopButton.onClick.RemoveListener(OnStopButtonClick);
        _roundButton.onClick.RemoveListener(OnRoundButtonClick);
    }

    private void Update()
    {
        if (_isPlaying)
        {
            _elapsedTime = DateTime.Now - _playTime;

            DisplayTime();
        }
    }

    private void OnStartButtonClick()
    {
        _isPlaying = true;
        _playTime = DateTime.Now;

        _roundButton.interactable = true;
        _roundCreator.Restart();
    }

    private void OnStopButtonClick()
    {
        _elapsedTime = TimeSpan.Zero;
        _isPlaying = false;

        _roundButton.interactable = false;
    }

    private void OnRoundButtonClick()
    {
        if (_isPlaying)
        {
            _roundCreator.Create($"{_elapsedTime:mm\\:ss\\,ff}");
        }        
    }

    private void DisplayTime()
    {
        _clock.text = $"{_elapsedTime:mm\\:ss\\,ff}";
    }
}
