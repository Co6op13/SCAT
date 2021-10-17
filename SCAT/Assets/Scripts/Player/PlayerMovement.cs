using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData _player; 

    private Vector2 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _player._moveDirection ;
        //if (_velocity.x < 0)
        //    flip(-1);
        //if (_velocity.x > 0)
        //    flip(1);

    }

    //private void flip(float _direction)
    //{

    //    _player._rigidbody.transform.localScale = new Vector2(_direction, 1);
    //}

    private void FixedUpdate()
    {
       _player._rigidbody.MovePosition(_player._rigidbody.position + _velocity * Time.fixedDeltaTime * _player._speedMovement);
    }
}
