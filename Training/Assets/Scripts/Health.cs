using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoint;
    [SerializeField] private Bar _bar;

    private int _point;

    public event UnityAction<int, int> ChangedHeatlh;

    private void Start()
    {
        _point = _maxPoint;
        ChangedHeatlh?.Invoke(_point, _maxPoint);
    }

    public void TakeDamage(int damage)
    {
        _point -= damage;
        CauseChangeInBar();
    }

    public void Recuperate(int point)
    {
        _point += point;
        CauseChangeInBar();
    }

    private void CauseChangeInBar()
    {
        _point = Mathf.Clamp(_point, 0, _maxPoint);
        ChangedHeatlh?.Invoke(_point, _maxPoint);
    }
}