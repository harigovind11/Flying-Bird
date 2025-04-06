using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyAbility : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 15f;
    
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _rb.velocity = Vector2.up * _velocity;
   
        }

    }

    private void FixedUpdate()
    {
              transform.rotation = Quaternion.Euler(0,0,_rb.velocity.y *_rotationSpeed );
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.GameOver();
    }
}
