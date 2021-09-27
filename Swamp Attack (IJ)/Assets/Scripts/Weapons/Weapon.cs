using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] protected int Damage;
    [SerializeField] protected int Price;
    [SerializeField] protected bool IsBought;
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected Bullet Bullet;

    protected Animator Animator;

    public string Name { get => _name; protected set => _name = value; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void Attack(Transform startShootingPoint);
}
