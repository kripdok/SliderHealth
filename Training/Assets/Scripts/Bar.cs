using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speedValueChange;

    private Coroutine _valueChange;
    private Slider _slider;
    private float _correctValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _health.ChangedHeatlh += OnValueChange;
    }

    private void OnDisable()
    {
        _health.ChangedHeatlh -= OnValueChange;
    }

    private void OnValueChange(int value, int maxValue)
    {
        if (_valueChange != null)
        {
            StopCoroutine(_valueChange);
        }

        _correctValue = (float)value / maxValue;
        _valueChange = StartCoroutine(ValueChange());
    }

    private IEnumerator ValueChange()
    {
        WaitForSeconds wait = new WaitForSeconds(_speedValueChange * Time.deltaTime);

        while (_slider.value != _correctValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _correctValue, _speedValueChange * Time.deltaTime);
            yield return wait;
        }
    }
}