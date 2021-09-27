using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _startShootPoint;
    [SerializeField] private float _secondsToInactive = 5f;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private Animator _animator;

    public bool IsDead { get; private set; }
    public int Money { get; private set; }

    private void Start()
    {
        IsDead = false;
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currentHealth > 0)
        {
            _currentWeapon.Attack(_startShootPoint);
        }
    }

    private IEnumerator Die()
    {
        Debug.Log(_currentWeapon.Name);
        _animator.Play(PlayerAnimations.Dying.GetNameWithGun(_currentWeapon.Name));
        yield return new WaitForSeconds(_secondsToInactive);
        gameObject.SetActive(false);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            IsDead = true;
            StartCoroutine(Die());
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }
}
