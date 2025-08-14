using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
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
