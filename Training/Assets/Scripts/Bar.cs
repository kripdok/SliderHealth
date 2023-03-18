using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speedValueChange;

    private Slider _slider;
    private float _correctValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _health.ChangeHeatlh += OnValueChange;
    }

    private void OnDisable()
    {
        _health.ChangeHeatlh -= OnValueChange;
    }

    private void Update()
    {
        if (_slider.value != _correctValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _correctValue, _speedValueChange * Time.deltaTime);
        }
    }

    private void OnValueChange(int value, int maxValue)
    {
        _correctValue = (float)value / maxValue;
    }
}