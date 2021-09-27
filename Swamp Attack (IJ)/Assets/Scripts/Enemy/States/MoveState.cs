﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private float _speed;

    private void Awake()
    {
        _speed = GetComponent<Enemy>().MoveSpeed;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);   
    }
}
