using UnityEngine;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    [SerializeField] private Transform _objectForRemoving;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnRemoveButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnRemoveButtonClick);
    }

    private void OnRemoveButtonClick()
    {
        Destroy(_objectForRemoving.gameObject);
    }
}
