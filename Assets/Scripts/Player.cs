using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Item> _inventory;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 1.0f;

    public static Player Instance { get; private set; } // singleton stuff

    // singleton stuff
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    // movement
    private void Update ()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }

        _spriteRenderer.sortingOrder = -(int)transform.position.y;
    }

    private void ShowDialogue ()
    {
        Debug.Log("player dialogue not implemented!");
    }
}