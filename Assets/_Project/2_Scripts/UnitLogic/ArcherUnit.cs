using System.Collections;
using UnityEngine;

public class ArcherUnit : Unit
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shootPoint;

    private Unit _currentTarget;
    private Projectile _currentProjectile;

    private readonly int ShootAnimHash = Animator.StringToHash("Shoot");
    private readonly int IsRunAnimHash = Animator.StringToHash("IsRun");

    public override IEnumerator MakeMove(Unit target = null)
    {
        if (health.isDead || target == null) yield break;
        _currentProjectile = null;
        _currentTarget = target;

        _anim.SetTrigger(ShootAnimHash);
        yield return new WaitUntil(() => _currentProjectile != null);

        yield return _currentProjectile.FlyToTarget(_currentTarget, 1f / _attackSpeed);
        _currentTarget.health.TryTakeDamage(_damage);
        Destroy(_currentProjectile.gameObject);
        yield return null;
    }

    protected void Shoot() => _currentProjectile = Instantiate(_projectile, _shootPoint.position, Quaternion.identity);

    public void IncreaseDamage(float value) => _damage += value;
    public void IncreaseSpeed(float value) => _attackSpeed += value;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        float timeElapsed = 0f, t = 0f;
        Vector2 startPos = transform.position;
        while (t < 1f)
        {
            _anim.SetBool(IsRunAnimHash, true);
            timeElapsed += Time.deltaTime;
            t = timeElapsed / 1f;
            Vector2 pos = Vector2.Lerp(startPos, point, t);
            transform.position = pos;
            yield return null;
        }

        _anim.SetBool(IsRunAnimHash, false);
        transform.position = point;
    }
}
