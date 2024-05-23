using UnityEngine;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private bool _isStartButton;

    private Button _button;
    private Image _image;
    private Sprite _normalSprite;
    private bool _isSelected;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _normalSprite = _image.sprite;
        _isSelected = false;

        foreach (Button button in _buttons)
        {
            button.onClick.AddListener(OnButtonsClick);
        }

        _button.onClick.AddListener(OnButtonClick);

        if (_isStartButton)
        {
            OnButtonClick();
        }
    }

    private void OnDisable()
    {
        foreach (Button button in _buttons)
        {
            button.onClick.RemoveListener(OnButtonsClick);
        }

        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonsClick()
    {
        _image.sprite = _normalSprite;
        _isSelected = false;
    }

    private void OnButtonClick()
    {
        if (_isSelected == false)
        {
            _image.sprite = _selectedSprite;
            _isSelected = true;
        }
    }
}