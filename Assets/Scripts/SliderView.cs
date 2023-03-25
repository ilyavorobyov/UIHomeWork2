using System.Collections;
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
    private Coroutine _changeValue;

    private void Start()
    {
        _slider.maxValue = _playerHealth.Health;
        _maxSliderValue = _playerHealth.Health;
        _slider.value = _maxSliderValue;
    }

    private void ChangeSliderValue()
    {
        if (_changeValue != null)
        {
            StopCoroutine(_changeValue);
        }

        _changeValue = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        _newValue = _playerHealth.Health;
        var waitFixedUpdate = new WaitForFixedUpdate();

        while (_slider.value != _newValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _newValue, _handleSpeed * Time.deltaTime);

            yield return waitFixedUpdate;
        }
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