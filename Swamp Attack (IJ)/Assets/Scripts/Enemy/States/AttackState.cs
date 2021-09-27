using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _delay;

    private Enemy _thisEnemy;
    private float _lastAttackTime;

    private void Awake()
    {
        _lastAttackTime = _delay;
        _thisEnemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            _thisEnemy.Attack();
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
}
