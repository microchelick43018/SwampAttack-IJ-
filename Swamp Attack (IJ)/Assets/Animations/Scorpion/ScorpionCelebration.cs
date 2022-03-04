using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScorpionCelebration : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 1.5f;

    private Vector3 _jumpVector;

    private void OnEnable()
    {
        _jumpVector = new Vector3(transform.position.x, transform.position.y + _jumpHeight, transform.position.z);
        transform.DOMove(_jumpVector, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
}
