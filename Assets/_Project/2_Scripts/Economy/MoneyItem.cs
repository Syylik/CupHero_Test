using System.Collections;
using UnityEngine;

public class MoneyItem : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _duration = 1f;

    private void Start() => StartCoroutine(CollectAnimation());

    private IEnumerator CollectAnimation()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));

        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;

        float time = 0f;
        while (time < _duration)
        {
            time += Time.deltaTime;
            float t = time / _duration;

            float curveValue = _scaleCurve.Evaluate(t);
            transform.position = new Vector2(transform.position.x, transform.position.y + curveValue);
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, curveValue);

            yield return null;
        }
        Bank.Instance.AddMoney();
        transform.localScale = endScale;
        Destroy(gameObject);
    }

    // private IEnumerator FlyToBank(Vector3 a, Vector3 b)
    // {
    //     yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));

    //     for (float t = 0; t < 1f; t += Time.deltaTime)
    //     {
    //         float x = Mathf.Lerp(a.x, b.x, t);

    //         float yInterpolate = _moveCurve.Evaluate(t);
    //         float y = Mathf.LerpUnclamped(a.y, b.y, yInterpolate);

    //         Vector3 position = new Vector3(x, y, 0f);
    //         transform.position = position;
    //         yield return null;
    //     }
    //     Destroy(gameObject);
    // }
}
