using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private UnityEvent _healthСhange = new UnityEvent();

    private float _damage = 10;
    private float _healing = 10;
    private float _maxHealth = 100;
    private float _minHealth = 0;

    public float Health { get; private set; } = 100;

    public event UnityAction HealthСhange
    {
        add => _healthСhange.AddListener(value);
        remove => _healthСhange.RemoveListener(value);
    }

    public void TakeDamage()
    {
        if (Health - _damage < _minHealth)
        {
            Debug.Log($"У игрока {_minHealth} ХП, нанесение урона невозможно!");
        }
        else
        {
            Health -= _damage;
            _healthСhange.Invoke();
        }
    }

    public void AddHealth()
    {
        if (Health + _healing > _maxHealth)
        {
            Debug.Log("У игрока максимальное здоровье");
        }
        else
        {
            Health += _healing;
            _healthСhange.Invoke();
        }
    }
}