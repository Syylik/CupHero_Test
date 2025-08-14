using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float _damage = 2f;
    public float Damage => _damage;
    [SerializeField] protected float _attackSpeed = 1f;
    public float AttackSpeed => _attackSpeed;

    public Health health { get; private set; }

    protected Animator _anim { get; private set; }

    private void Awake()
    {
        health ??= GetComponent<Health>();
        _anim ??= GetComponent<Animator>();
    }
    public abstract IEnumerator MakeMove(Unit target = null);

    public virtual IEnumerator MoveToPoint(Vector2 point) { return null; }
}
