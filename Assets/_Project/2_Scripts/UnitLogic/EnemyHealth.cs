using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyHealth : Health
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private MoneyItem _drop;
    private Animator _anim;

    private void Awake()
    {
        _healthBar.Init(this);

        _anim ??= GetComponent<Animator>();
        OnHealthChanged?.AddListener((float a, float b) => _anim.SetTrigger(TakeHitAnimHash));
        OnDie?.AddListener(() => _anim.SetTrigger(DeadAnimHash));
        OnDie?.AddListener(() => Instantiate(_drop, transform.position, Quaternion.identity));
    }
}
