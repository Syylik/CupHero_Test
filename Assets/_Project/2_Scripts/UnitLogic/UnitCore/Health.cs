using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    public float HealthValue => _health;
    private float _maxHealth;

    // :( weirdest thing i do ever
    [SerializeField] private DamageTextEffect _damageEffect;

    public UnityEvent<float, float> OnHealthChanged;
    public UnityEvent OnDie;

    public bool isDead { get; private set; }

    protected readonly int TakeHitAnimHash = Animator.StringToHash("Hit");
    protected readonly int DeadAnimHash = Animator.StringToHash("Die");

    private void Start() => _maxHealth = _health;

    public bool TryTakeDamage(float damage)
    {
        if (isDead) return false;
        _health -= damage;
        OnHealthChanged?.Invoke(_health, _maxHealth);
        SpawnDamageEffect(damage);
        if (_health <= 0)
        {
            _health = 0;

            Die();
        }

        return true;
    }

    public void Die()
    {
        isDead = true;
        OnDie?.Invoke();
    }

    public void IncreaseMaxHealth(float value)
    {
        _maxHealth += value;
        _health += value;

        OnHealthChanged?.Invoke(_health, _maxHealth);
    }

    private void SpawnDamageEffect(float damage) => Instantiate(_damageEffect, transform.position, Quaternion.identity).Init(damage);
}