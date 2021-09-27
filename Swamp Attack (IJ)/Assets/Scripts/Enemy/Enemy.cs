using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int MaxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] protected string Name;
    [SerializeField] protected int Reward;
    [SerializeField] protected Player Target;

    public int CurrentHealth { get; protected set; }
    protected Animator Animator;

    public int Damage { get => _damage; protected set => _damage = value; }
    public float MoveSpeed { get => _moveSpeed; protected set => _moveSpeed = value; }

    public event UnityAction Dying;

    private void Start()
    {      
        Animator = GetComponent<Animator>();   
    }

    private void OnEnable()
    {
        Dying += Die;
    }

    private void OnDisable()
    {
        Dying -= Die;
    }

    public void Attack()
    {
        Animator.Play(EnemiesAnimations.Attack);
        Target.ApplyDamage(Damage);
    }

    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Dying?.Invoke();
        }
    }

    public void Init(Player target)
    {
        Target = target;
    }

    public void Die()
    {
        Target.AddMoney(Reward);
        gameObject.SetActive(false);
    }

    public Player GetTarget()
    {
        return Target;
    }
}
