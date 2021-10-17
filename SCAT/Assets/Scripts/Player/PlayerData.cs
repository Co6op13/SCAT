using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerData : MonoBehaviour 
{
    [SerializeField] internal float _speedMovement;
    [SerializeField, Range(0.01f,0.1f)] internal float _speedMoveExtraGun = 0.05f;

    [SerializeField] internal bool isExtraGunLocked = false;

    
    internal PlayerInput _input;
    internal Rigidbody2D _rigidbody;
    internal BoxCollider2D _collider;
    internal Vector2 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
