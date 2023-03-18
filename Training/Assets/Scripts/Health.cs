using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoint;
    [SerializeField] private Bar _bar;

    private int _point;

    public event UnityAction<int, int> ChangeHeatlh;

    private void Start()
    {
        _point = _maxPoint;
        ChangeHeatlh?.Invoke(_point, _maxPoint);
    }

    public void TakeDamage(int damage)
    {
        _point -= damage;
        ChangeHeatlh?.Invoke(_point, _maxPoint);

        if (_point < 0)
        {
            _point = 0;
        }
    }

    public void Recuperate(int point)
    {
        _point += point;
        ChangeHeatlh?.Invoke(_point, _maxPoint);

        if (_point > _maxPoint)
        {
            _point = _maxPoint;
        }
    }
}