using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private GameObject _explosion;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _explosion.SetActive(false);
        _playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _playerController.Alive = false;
            _spriteRenderer.enabled = false;
            StartCoroutine(LoseScreen());
            _explosion.SetActive(true);
        }
    }

    private IEnumerator LoseScreen()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Lose");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
