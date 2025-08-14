using System;
using UnityEngine;

public class ProjectileVFX : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;

    public void OnHitEffects(Vector2 hitPoint)
    {
        Instantiate(_hitEffect, hitPoint, Quaternion.identity);
    }
}