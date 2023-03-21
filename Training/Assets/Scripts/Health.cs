using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoint;
    [SerializeField] private Bar _bar;

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
        �heckForClamping();
    }

    public void Recuperate(int point)
    {
        _point += point;
        �heckForClamping();
    }

    private void �heckForClamping()
    {
        _point = Mathf.Clamp(_point, 0, _maxPoint);
        Changed?.Invoke(_point, _maxPoint);
    }
}