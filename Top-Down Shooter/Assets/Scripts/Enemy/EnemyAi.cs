using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform _playerTransform;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _rotationSpeed = 120f;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _direction = (Vector2)_playerTransform.position - (Vector2)_rb.position;
        _direction = _direction.normalized;

        float rotateAmount = Vector3.Cross(_direction, transform.up).z;

        //transform.LookAt(_playerTransform);
        _rb.angularVelocity = -rotateAmount * _rotationSpeed;

        _rb.velocity = transform.up * _speed;
    }

    
}
