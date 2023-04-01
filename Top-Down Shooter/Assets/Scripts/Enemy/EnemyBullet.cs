using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed = 20;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
