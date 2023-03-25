using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _handleSpeed;

    private float _maxSliderValue;
    private float _newValue;
    private bool _isChangeSliderValue = false;

    private void Start()
    {
        _slider.maxValue = _playerHealth.Health;
        _maxSliderValue = _playerHealth.Health;
        _slider.value = _maxSliderValue;
    }

    private void Update()
    {
        if(_isChangeSliderValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _newValue, _handleSpeed * Time.deltaTime);

            if(_slider.value == _newValue)
            {
                _isChangeSliderValue = false;
            }
        }
    }

    private void ChangeSliderValue()
    {
        _newValue = _playerHealth.Health;
        _isChangeSliderValue = true;
    }

    private void OnEnable()
    {
        _playerHealth.Health—hange += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _playerHealth.Health—hange -= ChangeSliderValue;
    }
}