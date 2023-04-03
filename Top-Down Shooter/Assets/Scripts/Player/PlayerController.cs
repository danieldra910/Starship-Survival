using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    Camera _camera;

    private PlayerInputs _playerInput;

    private Vector2 _position;
    private Vector2 _mousePosition;

    [SerializeField]
    private Transform _bulletOne, _bulletTwo; //bullet locations

    [SerializeField]
    private GameObject _bullet;

    private Rigidbody2D _rb;

    private bool _canAim;

    public bool Alive;

    [System.Serializable]
    public class BulletPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<BulletPool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Awake()
    {
        _canAim = true;
        _playerInput = new PlayerInputs();
        _rb = GetComponent<Rigidbody2D>();
        Alive = true;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (BulletPool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Gameplay.Movement.performed += Movement;
        _playerInput.Gameplay.Movement.canceled += Movement;

        if(_canAim)
        {
            _playerInput.Gameplay.MousePos.performed += Aim;
        }

        if( Alive)
        {
            _playerInput.Gameplay.Shoot.performed += Shoot;
        }
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(_position * _speed);

        Vector2 facingDirection = _mousePosition - _position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg -90;
        _rb.MoveRotation(angle);
    }

    private void Movement(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
    }

    private void Aim(InputAction.CallbackContext context)
    {
        _mousePosition = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        _canAim = false;
        Instantiate(_bullet, _bulletOne.position,_bulletOne.rotation);
        Instantiate(_bullet, _bulletTwo.position,_bulletTwo.rotation);
        yield return new WaitForSeconds(1.5f);
        _canAim = true;

    }
}
