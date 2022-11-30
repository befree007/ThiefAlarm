using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed;
    }
}
