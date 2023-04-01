using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed = 20;
    [SerializeField]
    private GameObject _explosion;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerScore.Score += 10;
            Instantiate(_explosion,other.transform.position,other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
