using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.transform.position, _moveSpeed);
    }
}
