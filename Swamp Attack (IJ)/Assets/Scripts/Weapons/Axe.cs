using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private float _hitTime = 1f;

    private bool _ableToAttack;
    private List<Enemy> _enemiesInCollider = new List<Enemy>();

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _ableToAttack = true;
    }

    public override void Attack(Transform startShootingPoint)
    {
        if (_ableToAttack)
        {
            Animator.Play(PlayerAnimations.Attack.GetNameWithGun(Name));
            StartCoroutine(HitEnemies(_enemiesInCollider));
        }
    }

    private IEnumerator HitEnemies(List<Enemy> enemies)
    {
        _ableToAttack = false;
        yield return new WaitForSeconds(_hitTime);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].ApplyDamage(Damage);
        }
        RemoveDeadEnemiesFromList(enemies);
        yield return new WaitForSeconds(_attackCooldown);
        _ableToAttack = true;
    }

    private void RemoveDeadEnemiesFromList(List<Enemy> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isActiveAndEnabled == false)
            {
                enemies.RemoveAt(i);
                i--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemiesInCollider.Add(enemy);
        }
    }
}
