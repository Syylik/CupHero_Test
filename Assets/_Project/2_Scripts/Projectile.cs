using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private AnimationCurve _trajectoryCurve; // configure height of trajectory 

    private ProjectileVFX _vfx;

    private void Awake()
    {
        _vfx = GetComponent<ProjectileVFX>();
    }

    public IEnumerator FlyToTarget(Unit target, float flyTime = 1f)
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = target.transform.position;
        float t = 0f, _timeElapsed = 0f;

        while (t < 1f)
        {
            _timeElapsed += Time.deltaTime;
            t = _timeElapsed / flyTime;

            Vector2 pos = Vector2.Lerp(startPos, endPos, t);
            pos.y += _trajectoryCurve.Evaluate(t);

            transform.position = pos;
            yield return null;
        }

        transform.position = endPos;
        _vfx.OnHitEffects(transform.position);
        yield break;
    }

    // private void HitTarget(Health target, float damage)
    // {
    //     target.TryTakeDamage(damage);
    //     Destroy(gameObject);
    // }
}
