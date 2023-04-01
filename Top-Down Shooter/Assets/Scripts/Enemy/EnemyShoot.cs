using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shootTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        StartCoroutine(ShootBullets());
    }
    private IEnumerator ShootBullets()
    {
        Instantiate(_bullet, _shootTransform.position, _shootTransform.rotation);

        yield return new WaitForSeconds(3f);


    }
}
