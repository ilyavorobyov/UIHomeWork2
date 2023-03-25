using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private float _damage = 10;
    private float _healing = 10;
    private float _maxHealth = 100;
    private float _minHealth = 0;

    public event UnityAction Health—hange;

    public float Health { get; private set; } = 100;

    public void Damage()
    {
        Health -= _damage;
        Health = Mathf.Clamp(Health, _minHealth, _maxHealth);
        Health—hange.Invoke();
    }

    public void Heal()
    {
        Health += _healing;
        Health = Mathf.Clamp(Health, _minHealth, _maxHealth);
        Health—hange.Invoke();
    }
}