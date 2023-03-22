using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoint;

    private int _point;

    public event UnityAction<int, int> Changed;

    private void Start()
    {
        _point = _maxPoint;
        Changed?.Invoke(_point, _maxPoint);
    }

    public void TakeDamage(int damage)
    {
        _point -= damage;
        ChangePointsWithinTheClamp();
    }

    public void Recuperate(int point)
    {
        _point += point;
        ChangePointsWithinTheClamp();
    }

    private void ChangePointsWithinTheClamp()
    {
        _point = Mathf.Clamp(_point, 0, _maxPoint);
        Changed?.Invoke(_point, _maxPoint);
    }
}