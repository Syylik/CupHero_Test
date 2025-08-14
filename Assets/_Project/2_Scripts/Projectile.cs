using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _flyTime = 1f;
    [SerializeField] private AnimationCurve _trajectoryCurve; // configure height of trajectory 

    public IEnumerator FlyToTarget(Unit target)
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = target.transform.position;
        float t = 0f, _timeElapsed = 0f;

        while (t < 1f)
        {
            _timeElapsed += Time.deltaTime;
            t = _timeElapsed / _flyTime;

            Vector2 pos = Vector2.Lerp(startPos, endPos, t);
            pos.y += _trajectoryCurve.Evaluate(t);

            transform.position = pos;
            yield return null;
        }

        transform.position = endPos;
        // HitTarget(target.health, damage);
        yield break;
    }

    // private void HitTarget(Health target, float damage)
    // {
    //     target.TryTakeDamage(damage);
    //     Destroy(gameObject);
    // }
}
