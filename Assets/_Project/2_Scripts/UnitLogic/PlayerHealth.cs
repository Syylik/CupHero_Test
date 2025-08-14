using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : Health
{
    [SerializeField] private HealthBar _healthBar;
    private Animator _anim;

    private void Awake()
    {
        _healthBar.Init(this);

        _anim ??= GetComponent<Animator>();
        OnHealthChanged?.AddListener((float a, float b) => _anim.SetTrigger(TakeHitAnimHash));
        OnDie?.AddListener(() => _anim.SetTrigger(DeadAnimHash));
    }
}
