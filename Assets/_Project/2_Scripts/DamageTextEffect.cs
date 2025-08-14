using System.Collections;
using TMPro;
using UnityEngine;

public class DamageTextEffect : MonoBehaviour
{
    [SerializeField] private float _moveUpSpeed = 1f;
    [SerializeField] private float _fadeDuration = 0.5f;

    [SerializeField] private TMP_Text _damageText;

    public void Init(float damage)
    {
        _damageText.text = damage.ToString();
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        float elapsed = 0f;
        Color startColor = _damageText.color;
        Vector3 startPos = transform.position;

        while (elapsed < _fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / _fadeDuration;

            transform.position = startPos + Vector3.up * _moveUpSpeed * t;

            _damageText.color = new Color(startColor.r, startColor.g, startColor.b, 1 - t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
